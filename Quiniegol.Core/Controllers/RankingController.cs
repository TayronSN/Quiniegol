using Quiniegol.Core.Models;
using Quiniegol.Core.Data;

namespace Quiniegol.Core.Controllers
{
    public class RankingController
    {

        public List<Ranking> GenerarRanking()
        {
            List<Ranking> ranking = new List<Ranking>();

            // Se parte de todos los usuarios normales (sin administradores), con 0 puntos
            foreach (Usuario usuario in UsuariosData.LeerUsuarios())
            {
                if (usuario.IdRol != 1)
                {
                    ranking.Add(new Ranking { IdEmpleado = usuario.IdEmpleado, Puntos = 0 });
                }
            }

            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();

            foreach (Pronostico pronostico in pronosticos)
            {
                Partido? partido = PartidosData.BuscarPorId(pronostico.IdPartido);

                // Si el partido no existe o no está cerrado, no cuenta
                if (partido == null || partido.Estado != "Cerrado")
                {
                    continue;
                }

                // Solo cuenta si el pronóstico coincide con el resultado real
                if (pronostico.ResultadoPronosticado != partido.Resultado)
                {
                    continue;
                }

                // Se busca al jugador en la lista y se le suman 5 puntos
                Ranking? jugador = ranking.FirstOrDefault(r => r.IdEmpleado == pronostico.IdEmpleado);

                if (jugador != null)
                {
                    jugador.Puntos += 5;
                }
            }

            // Se ordena de mayor a menor puntos
            return ranking.OrderByDescending(r => r.Puntos).ToList();
        }

    }
}