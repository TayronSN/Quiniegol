using Quiniegol.Core.Data;
using Quiniegol.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Core.Controllers
{
    // Calcula estadísticas globales (administrador) y personales (usuario).
    public class EstadisticasController
    {
        //  ADMINISTRADOR 

        // El resultado (Local, Empate, Visitante) que más veces ocurrió.
        public string ObtenerResultadoMasRepetido()
        {
            List<Partido> cerrados = PartidosData.LeerPartidos()
                .Where(p => !string.IsNullOrWhiteSpace(p.Resultado))
                .ToList();

            if (cerrados.Count == 0)
            {
                return "Sin resultados";
            }

            return cerrados
                .GroupBy(p => p.Resultado)
                .OrderByDescending(g => g.Count())
                .First().Key!;
        }

        // El partido cerrado donde más usuarios acertaron.
        public Partido? ObtenerPartidoConMasAciertos()
        {
            Partido? mejor = null;
            int mayor = 0;

            foreach (Partido partido in PartidosData.LeerPartidos())
            {
                if (string.IsNullOrWhiteSpace(partido.Resultado))
                {
                    continue;
                }

                int aciertos = ObtenerAciertosPartido(partido.IdPartido);

                if (aciertos > mayor)
                {
                    mayor = aciertos;
                    mejor = partido;
                }
            }

            return mejor;
        }

        // Cuántos usuarios acertaron el resultado de un partido.
        public int ObtenerAciertosPartido(int idPartido)
        {
            Partido? partido = PartidosData.BuscarPorId(idPartido);

            if (partido == null || string.IsNullOrWhiteSpace(partido.Resultado))
            {
                return 0;
            }

            return PronosticosData.LeerPronosticos().Count(p => p.IdPartido == idPartido && p.ResultadoPronosticado == partido.Resultado);
        }

        // Todos los usuarios ordenados de mayor a menor aciertos.
        public List<UsuarioEstadistica> ObtenerUsuariosConMasAciertos()
        {
            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();
            List<Partido> partidos = PartidosData.LeerPartidos();

            List<UsuarioEstadistica> lista = new List<UsuarioEstadistica>();

            foreach (Usuario usuario in UsuariosData.LeerUsuarios())
            {
                // Filtramos solo los pronósticos de este usuario.
                List<Pronostico> suyos = pronosticos .Where(p => p.IdEmpleado == usuario.IdEmpleado) .ToList();

                int aciertos = suyos.Count(p =>
                {
                    Partido? partido = partidos.FirstOrDefault(x => x.IdPartido == p.IdPartido);
                    return partido != null &&  !string.IsNullOrWhiteSpace(partido.Resultado) &&  p.ResultadoPronosticado == partido.Resultado;
                });

                lista.Add(new UsuarioEstadistica
                {
                    IdEmpleado  = usuario.IdEmpleado,
                    Nombre      = $"{usuario.Nombre} {usuario.Apellido}",
                    Pronosticos = suyos.Count,
                    Aciertos    = aciertos
                });
            }

            return lista.OrderByDescending(u => u.Aciertos).ThenBy(u => u.IdEmpleado).ToList();
        }

        // Los cinco usuarios con más aciertos.
        public List<UsuarioEstadistica> ObtenerTop5Aciertos()
        {
            return ObtenerUsuariosConMasAciertos().Take(5).ToList();
        }

        // Partidos ordenados de mayor a menor cantidad de pronósticos recibidos.
        public List<Partido> ObtenerPartidosConMasPronosticos()
        {
            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();

            return PartidosData.LeerPartidos() .OrderByDescending(p => pronosticos.Count(pr => pr.IdPartido == p.IdPartido)).ThenBy(p => p.IdPartido).ToList();
        }

        // Cuántos pronósticos tiene un partido.
        public int ObtenerCantidadPronosticos(int idPartido)
        {
            return PronosticosData.LeerPronosticos() .Count(p => p.IdPartido == idPartido);
        }

        // Partidos cerrados donde ningún usuario acertó.
        public List<Partido> ObtenerPartidosSinAciertos()
        {
            return PartidosData.LeerPartidos().Where(p => !string.IsNullOrWhiteSpace(p.Resultado) && ObtenerAciertosPartido(p.IdPartido) == 0) .ToList();
        }

        // El equipo que más veces ganó siendo el menos votado por los usuarios.
        public Equipo? ObtenerEquipoSorpresa()
        {
            List<Partido> partidos       = PartidosData.LeerPartidos();
            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();
            List<Equipo> equipos         = EquiposData.LeerEquipos();

            // Cuenta cuántas veces cada equipo fue el equipo sorpresa.
            Dictionary<int, int> sorpresas = new Dictionary<int, int>();

            foreach (Partido partido in partidos)
            {
                if (string.IsNullOrWhiteSpace(partido.Resultado) || partido.Resultado == "Empate")
                {
                    continue;
                }

                List<Pronostico> apuestas = pronosticos .Where(p => p.IdPartido == partido.IdPartido) .ToList();

                if (apuestas.Count == 0)
                {
                    continue;
                }

                int votosLocal     = apuestas.Count(p => p.ResultadoPronosticado == "Local");
                int votosVisitante = apuestas.Count(p => p.ResultadoPronosticado == "Visitante");
                int votosEmpate    = apuestas.Count(p => p.ResultadoPronosticado == "Empate");
                int mayorVotos     = new[] { votosLocal, votosEmpate, votosVisitante }.Max();

                // Sin mayoría clara, no aplica.
                if (new[] { votosLocal, votosEmpate, votosVisitante }.Count(v => v == mayorVotos) > 1)
                {
                    continue;
                }

                string masVotado = votosLocal == mayorVotos ? "Local"
                                 : votosEmpate == mayorVotos ? "Empate"
                                 : "Visitante";

                // Si ganó lo que la mayoría esperaba, no fue sorpresa.
                if (masVotado == partido.Resultado)
                {
                    continue;
                }

                int idSorpresa = partido.Resultado == "Local" ? partido.IdEquipoLocal: partido.IdEquipoVisitante;

                if (!sorpresas.ContainsKey(idSorpresa))
                {
                    sorpresas[idSorpresa] = 0;
                }

                sorpresas[idSorpresa]++;
            }

            if (sorpresas.Count == 0)
            {
                return null;
            }

            int idGanador = sorpresas.OrderByDescending(e => e.Value).First().Key;

            return equipos.FirstOrDefault(e => e.IdEquipo == idGanador);
        }

        //  USUARIO 

        // El equipo al que el usuario más veces le apostó a ganar.
        public Equipo? ObtenerEquipoMasApostado(string idEmpleado)
        {
            List<Partido> partidos   = PartidosData.LeerPartidos();
            List<Equipo> equipos     = EquiposData.LeerEquipos();

            Dictionary<int, int> conteo = new Dictionary<int, int>();

            foreach (Pronostico pronostico in PronosticosData.LeerPronosticos().Where(p => p.IdEmpleado == idEmpleado))
            {
                Partido? partido = partidos.FirstOrDefault(p => p.IdPartido == pronostico.IdPartido);

                if (partido == null)
                {
                    continue;
                }

                // El empate no tiene equipo ganador, se ignora.
                int idEquipo;

                if (pronostico.ResultadoPronosticado == "Local")
                {
                    idEquipo = partido.IdEquipoLocal;
                }
                else if (pronostico.ResultadoPronosticado == "Visitante")
                {
                    idEquipo = partido.IdEquipoVisitante;
                }
                else
                {
                    continue;
                }

                if (!conteo.ContainsKey(idEquipo))
                {
                    conteo[idEquipo] = 0;
                }

                conteo[idEquipo]++;
            }

            if (conteo.Count == 0)
            {
                return null;
            }

            int idMasApostado = conteo.OrderByDescending(e => e.Value).First().Key;

            return equipos.FirstOrDefault(e => e.IdEquipo == idMasApostado);
        }

        // Cuántos pronósticos acertó el usuario en partidos cerrados.
        public int ObtenerAciertosUsuario(string idEmpleado)
        {
            List<Partido> partidos = PartidosData.LeerPartidos();

            return PronosticosData.LeerPronosticos()
                .Where(p => p.IdEmpleado == idEmpleado)
                .Count(p =>
                {
                    Partido? partido = partidos.FirstOrDefault(x => x.IdPartido == p.IdPartido);
                    return partido != null &&
                           !string.IsNullOrWhiteSpace(partido.Resultado) &&
                           p.ResultadoPronosticado == partido.Resultado;
                });
        }

        // Cuántos pronósticos en total ha realizado el usuario.
        public int ObtenerCantidadPronosticosUsuario(string idEmpleado)
        {
            return PronosticosData.LeerPronosticos().Count(p => p.IdEmpleado == idEmpleado);
        }

        // Porcentaje de aciertos: (aciertos / total) × 100.
        public double ObtenerPorcentajeAcierto(string idEmpleado)
        {
            int total = ObtenerCantidadPronosticosUsuario(idEmpleado);

            if (total == 0)
            {
                return 0;
            }

            return (double)ObtenerAciertosUsuario(idEmpleado) / total * 100;
        }

        //  INSIGNIAS 

        // Insignias que el usuario ha desbloqueado según su actividad.
        public List<Insignia> ObtenerInsigniasUsuario(string idEmpleado)
        {
            List<Insignia> insignias = new List<Insignia>();

            int pronosticos = ObtenerCantidadPronosticosUsuario(idEmpleado);
            int aciertos    = ObtenerAciertosUsuario(idEmpleado);

            if (pronosticos >= 1)
            {
                insignias.Add(new Insignia
                {
                    Nombre      = "Participante",
                    Descripcion = "Ha realizado al menos un pronóstico."
                });
            }

            if (aciertos >= 1)
            {
                insignias.Add(new Insignia
                {
                    Nombre      = "Primer acierto",
                    Descripcion = "Ha acertado al menos un pronóstico."
                });
            }

            if (aciertos >= 5)
            {
                insignias.Add(new Insignia
                {
                    Nombre      = "Buen pronosticador",
                    Descripcion = "Ha conseguido al menos 5 aciertos."
                });
            }

            if (aciertos >= 10)
            {
                insignias.Add(new Insignia
                {
                    Nombre      = "Experto",
                    Descripcion = "Ha conseguido al menos 10 aciertos."
                });
            }

            return insignias;
        }
    }
}
