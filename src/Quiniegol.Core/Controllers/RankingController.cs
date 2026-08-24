using Quiniegol.Core.Models;
using Quiniegol.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Quiniegol.Core.Controllers
{
    public class RankingController
    {

        public List<Ranking> GenerarRanking()
        {
            List<Ranking> ranking = new List<Ranking>();

            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();

            foreach (Pronostico pronostico in pronosticos)
            {
                Partido partido = PartidosData.BuscarPorId(pronostico.IdPartido);

                // Si el partido ya no existe, el pronóstico no puede utilizarse para calcular el ranking
                if (partido == null)
                {
                    continue;
                }

                // Solo se toman en cuenta partidos que ya finalizaron
                if (partido.Estado != "Cerrado")
                {
                    continue;
                }

                // El jugador solamente obtiene un punto si su pronóstico coincide con el resultado real del partido
                if (pronostico.ResultadoPronosticado != partido.Resultado)
                {
                    continue;
                }

                Ranking jugador = null;

                // Se busca si el empleado ya tiene una posición creada dentro del ranking para poder acumular sus puntos
                foreach (Ranking r in ranking)
                {
                    if (r.IdEmpleado == pronostico.IdEmpleado)
                    {
                        jugador = r;
                        break;
                    }
                }

                if (jugador == null)
                {
                    jugador = new Ranking();

                    jugador.IdEmpleado = pronostico.IdEmpleado;
                    jugador.Puntos = 1;

                    ranking.Add(jugador);
                }
                else
                {
                    // Si el jugador ya existe, se suma un punto por haber acertado otro pronóstico
                    jugador.Puntos++;
                }
            }

            // Se ordena el ranking de mayor a menor cantidad de puntos
            ranking = ranking.OrderByDescending(r => r.Puntos).ToList();

            return ranking;
        }

    }
}