using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.ExamenFinal.ModelDB;

namespace PAW.ExamenFinal.ModelDB.MisTablas
{
    public partial class Peliculas
    {
        CopiaPelicula pelicula = new CopiaPelicula();
        public string nombreMedio;
        public string TipoMedio
        {
            get
            {
                int? medio = pelicula.Medio;
                switch (medio)
                {
                    case 1:
                        nombreMedio = "DVD";
                        break;
                    case 2:
                        nombreMedio = "Blue Ray";
                        break;
                    case 3:
                        nombreMedio = "CD";
                        break;
                    case null:
                        nombreMedio = "No Indica o Desconocido";
                        break;
                    default:
                        nombreMedio = "Medio no Existente Utilice opciones de 1 a 3";
                        break;

                }
                return nombreMedio;
            }

        }
    }
}
