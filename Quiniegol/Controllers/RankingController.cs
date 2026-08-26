using Quiniegol.Data;
using Quiniegol.Models;

namespace Quiniegol.Controllers
{
    // Genera el ranking ordenado por puntos acumulados.
    internal class RankingController
    {
        public List<Ranking> GenerarRanking()
        {
            List<Ranking> ranking = new List<Ranking>();

            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();

            foreach (Pronostico pronostico in pronosticos)
            {
                Partido? partido = PartidosData.BuscarPorId(pronostico.IdPartido);

                if (partido == null || partido.Estado != "Cerrado")
                {
                    continue;
                }

                if (pronostico.ResultadoPronosticado != partido.Resultado)
                {
                    continue;
                }

                Ranking? jugador = null;

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
                    jugador = new Ranking { IdEmpleado = pronostico.IdEmpleado, Puntos = 5 };
                    ranking.Add(jugador);
                }
                else
                {
                    jugador.Puntos += 5;
                }
            }

            return ranking.OrderByDescending(r => r.Puntos).ToList();
        }
    }
}
