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

                if (partido == null)
                {
                    continue;
                }

                if (partido.Estado != "Cerrado")
                {
                    continue;
                }

                if (pronostico.ResultadoPronosticado != partido.Resultado)
                {
                    continue;
                }

                Ranking jugador = null;

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
                    jugador.Puntos++;
                }
            }

            ranking = ranking.OrderByDescending(r => r.Puntos).ToList();
            return ranking;
        }

    }
}
