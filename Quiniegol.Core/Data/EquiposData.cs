using Quiniegol.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Core.Data
{
    public class EquiposData
    {
        // Lee todos los equipos directamente desde la base de datos.
        public static List<Equipo> LeerEquipos()
        {
            using AppDbContext db = new AppDbContext();

            return db.Equipos.ToList();
        }

        // Busca un equipo por su ID dentro de la base de datos.
        public static Equipo? BuscarPorId(int idEquipo)
        {
            using AppDbContext db = new AppDbContext();

            return db.Equipos.FirstOrDefault(
                equipo => equipo.IdEquipo == idEquipo);
        }

        // Carga los equipos oficiales en la base de datos solamente si todavía no existen equipos registrados.
        public static void InicializarEquipos()
        {
            using AppDbContext db = new AppDbContext();

            if (db.Equipos.Any())
            {
                return;
            }

            List<Equipo> equipos = ObtenerEquiposOficiales();

            db.Equipos.AddRange(equipos);

            db.SaveChanges();
        }

        // Lista inicial de los equipos que utilizará el sistema, incluyendo su grupo y la ruta de la bandera correspondiente.
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