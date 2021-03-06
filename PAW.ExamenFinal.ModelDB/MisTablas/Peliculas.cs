﻿using System;
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
        public bool restringida;
        public int tiempoAnios;
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
        public bool Restringida
        {
            get
            {
                string genero = pelicula.Genero;
                if (genero == "(R)"|| genero=="Terror"|| genero == "Adultos" || genero == "Guerra" || genero == "Muerte")
                {
                    restringida = true;
                }
                else
                {
                    restringida = false;
                }
                return restringida;
            }
        }
        public int Decada
        {
            get
            {
                int publicada = pelicula.PublicadaEn;
                int anioActual = DateTime.Now.Year;
                int totalDecada = anioActual - publicada;
                return totalDecada;
            }
        }
        public int Duracion_Medio
        {
            get
            {
                DateTime? fechaPerdida = pelicula.FechaPerdidaDanada;
                DateTime? fechaCreacion = pelicula.FechaCreacion;
                if (fechaPerdida != null)
                {
                    tiempoAnios = Convert.ToInt32(((DateTime)fechaPerdida - (DateTime)fechaCreacion).TotalDays / 365.2425);
                }
                else
                {
                    tiempoAnios = Convert.ToInt32((DateTime.Today - (DateTime)fechaCreacion).TotalDays / 365.2425);
                }
                return tiempoAnios;
            }
        }
    }
}
