using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiniegol.Data
{
    internal class EquiposData
    {
        private static readonly string rutaArchivo = Path.GetFullPath(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\Data\equipos.json"
            )
        );

        public static void InicializarEquipos()
        {
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "[]");
            }

            List<Equipo> equipos = LeerEquipos();

            if (equipos.Count > 0)
            {
                return;
            }

            equipos = ObtenerEquiposOficiales();

            string json = JsonSerializer.Serialize(equipos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }

        public static List<Equipo> LeerEquipos()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Equipo>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Equipo>();
            }

            List<Equipo>? equipos = JsonSerializer.Deserialize<List<Equipo>>(json);

            return equipos ?? new List<Equipo>();
        }

        public static Equipo? BuscarPorId(int idEquipo)
        {
            foreach (Equipo equipo in LeerEquipos())
            {
                if (equipo.IdEquipo == idEquipo)
                {
                    return equipo;
                }
            }

            return null;
        }

        private static List<Equipo> ObtenerEquiposOficiales()
        {
            return new List<Equipo>
            {
                new Equipo{ IdEquipo=1, Nombre="Mexico", Grupo="A", Bandera="Resources/Banderas/mexico.png"},
                new Equipo{ IdEquipo=2, Nombre="Sudafrica", Grupo="A", Bandera="Resources/Banderas/sudafrica.png"},
                new Equipo{ IdEquipo=3, Nombre="Republica de Corea", Grupo="A", Bandera="Resources/Banderas/republicadecorea.png"},
                new Equipo{ IdEquipo=4, Nombre="Chequia", Grupo="A", Bandera="Resources/Banderas/chequia.png"},

                new Equipo{ IdEquipo=5, Nombre="Canada", Grupo="B", Bandera="Resources/Banderas/canada.png"},
                new Equipo{ IdEquipo=6, Nombre="Bosnia y Herzegovina", Grupo="B", Bandera="Resources/Banderas/bosnia.png"},
                new Equipo{ IdEquipo=7, Nombre="Catar", Grupo="B", Bandera="Resources/Banderas/catar.png"},
                new Equipo{ IdEquipo=8, Nombre="Suiza", Grupo="B", Bandera="Resources/Banderas/suiza.png"},

                new Equipo{ IdEquipo=9, Nombre="Brasil", Grupo="C", Bandera="Resources/Banderas/brasil.png"},
                new Equipo{ IdEquipo=10, Nombre="Marruecos", Grupo="C", Bandera="Resources/Banderas/marruecos.png"},
                new Equipo{ IdEquipo=11, Nombre="Haiti", Grupo="C", Bandera="Resources/Banderas/haiti.png"},
                new Equipo{ IdEquipo=12, Nombre="Escocia", Grupo="C", Bandera="Resources/Banderas/escocia.png"},

                new Equipo{ IdEquipo=13, Nombre="Estados Unidos", Grupo="D", Bandera="Resources/Banderas/estadosunidos.png"},
                new Equipo{ IdEquipo=14, Nombre="Paraguay", Grupo="D", Bandera="Resources/Banderas/paraguay.png"},
                new Equipo{ IdEquipo=15, Nombre="Australia", Grupo="D", Bandera="Resources/Banderas/australia.png"},
                new Equipo{ IdEquipo=16, Nombre="Turquia", Grupo="D", Bandera="Resources/Banderas/turquia.png"},

                new Equipo{ IdEquipo=17, Nombre="Alemania", Grupo="E", Bandera="Resources/Banderas/alemania.png"},
                new Equipo{ IdEquipo=18, Nombre="Curazao", Grupo="E", Bandera="Resources/Banderas/curazao.png"},
                new Equipo{ IdEquipo=19, Nombre="Costa de Marfil", Grupo="E", Bandera="Resources/Banderas/costademarfil.png"},
                new Equipo{ IdEquipo=20, Nombre="Ecuador", Grupo="E", Bandera="Resources/Banderas/ecuador.png"},

                new Equipo{ IdEquipo=21, Nombre="Paises Bajos", Grupo="F", Bandera="Resources/Banderas/paisesbajos.png"},
                new Equipo{ IdEquipo=22, Nombre="Japon", Grupo="F", Bandera="Resources/Banderas/japon.png"},
                new Equipo{ IdEquipo=23, Nombre="Suecia", Grupo="F", Bandera="Resources/Banderas/suecia.png"},
                new Equipo{ IdEquipo=24, Nombre="Tunez", Grupo="F", Bandera="Resources/Banderas/tunez.png"},

                new Equipo{ IdEquipo=25, Nombre="Belgica", Grupo="G", Bandera="Resources/Banderas/belgica.png"},
                new Equipo{ IdEquipo=26, Nombre="Egipto", Grupo="G", Bandera="Resources/Banderas/egipto.png"},
                new Equipo{ IdEquipo=27, Nombre="Ri de Iran", Grupo="G", Bandera="Resources/Banderas/iran.png"},
                new Equipo{ IdEquipo=28, Nombre="Nueva Zelanda", Grupo="G", Bandera="Resources/Banderas/nuevazelanda.png"},

                new Equipo{ IdEquipo=29, Nombre="España", Grupo="H", Bandera="Resources/Banderas/espana.png"},
                new Equipo{ IdEquipo=30, Nombre="Islas de Cabo Verde", Grupo="H", Bandera="Resources/Banderas/caboverde.png"},
                new Equipo{ IdEquipo=31, Nombre="Arabia Saudi", Grupo="H", Bandera="Resources/Banderas/arabiasaudita.png"},
                new Equipo{ IdEquipo=32, Nombre="Uruguay", Grupo="H", Bandera="Resources/Banderas/uruguay.png"},

                new Equipo{ IdEquipo=33, Nombre="Francia", Grupo="I", Bandera="Resources/Banderas/francia.png"},
                new Equipo{ IdEquipo=34, Nombre="Senegal", Grupo="I", Bandera="Resources/Banderas/senegal.png"},
                new Equipo{ IdEquipo=35, Nombre="Irak", Grupo="I", Bandera="Resources/Banderas/irak.png"},
                new Equipo{ IdEquipo=36, Nombre="Noruega", Grupo="I", Bandera="Resources/Banderas/noruega.png"},

                new Equipo{ IdEquipo=37, Nombre="Argentina", Grupo="J", Bandera="Resources/Banderas/argentina.png"},
                new Equipo{ IdEquipo=38, Nombre="Argelia", Grupo="J", Bandera="Resources/Banderas/argelia.png"},
                new Equipo{ IdEquipo=39, Nombre="Austria", Grupo="J", Bandera="Resources/Banderas/austria.png"},
                new Equipo{ IdEquipo=40, Nombre="Jordania", Grupo="J", Bandera="Resources/Banderas/jordania.png"},

                new Equipo{ IdEquipo=41, Nombre="Portugal", Grupo="K", Bandera="Resources/Banderas/portugal.png"},
                new Equipo{ IdEquipo=42, Nombre="RD Congo", Grupo="K", Bandera="Resources/Banderas/rdcongo.png"},
                new Equipo{ IdEquipo=43, Nombre="Uzbekistan", Grupo="K", Bandera="Resources/Banderas/uzbekistan.png"},
                new Equipo{ IdEquipo=44, Nombre="Colombia", Grupo="K", Bandera="Resources/Banderas/colombia.png"},

                new Equipo{ IdEquipo=45, Nombre="Inglaterra", Grupo="L", Bandera="Resources/Banderas/inglaterra.png"},
                new Equipo{ IdEquipo=46, Nombre="Croacia", Grupo="L", Bandera="Resources/Banderas/croacia.png"},
                new Equipo{ IdEquipo=47, Nombre="Ghana", Grupo="L", Bandera="Resources/Banderas/ghana.png"},
                new Equipo{ IdEquipo=48, Nombre="Panama", Grupo="L", Bandera="Resources/Banderas/panama.png"}
            };
        }
    }
}