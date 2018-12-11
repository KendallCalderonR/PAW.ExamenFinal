using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.ExamenFinal.ModelDB;

namespace PAW.ExamenFinal.ModelDB.MisTablas
{
    public partial class Clientes
    {
        Cliente cliente = new Cliente();

        public string AgeInYearsAndMounts
        {
            get
            {
                
                int? annos, meses;
                string resultado = string.Empty;
                int? laEdadEnAnnos = null;
                if ( cliente.FechaNacimiento != null)
                {
                    laEdadEnAnnos = (int)((DateTime.Today - (DateTime)cliente.FechaNacimiento).TotalDays / 365.2425);
                }

                if (laEdadEnAnnos != null)
                {
                    annos = laEdadEnAnnos / 365;
                    meses = laEdadEnAnnos % 365;
                    resultado = String.Format("{0} años y {1} meses",annos,meses);
                }
                return resultado;
            }
        }

        public string AgeInYearsAndMountsAfiliacion
        {
            get
            {

                int? annos, meses;
                string resultado = string.Empty;
                int? CantAnnosYMeses = null;
                if (cliente.FechaAfiliacion != null)
                {
                    CantAnnosYMeses = (int)((DateTime.Today - (DateTime)cliente.FechaAfiliacion).TotalDays / 365.2425);
                }

                if (CantAnnosYMeses != null)
                {
                    annos = CantAnnosYMeses / 365;
                    meses = CantAnnosYMeses % 365;
                    resultado = String.Format("{0} años y {1} meses", annos, meses);
                }
                return resultado;
            }
        }

        public int EdadDiaAfiliacion
        {
            get
            {
                int CantAnnosYMesesAfiliacion = 0;
                if (cliente.FechaAfiliacion != null)
                {
                    CantAnnosYMesesAfiliacion = (int)(((DateTime)cliente.FechaAfiliacion - (DateTime)cliente.FechaNacimiento).TotalDays / 365.2425);
                }

                return CantAnnosYMesesAfiliacion;
            }
        }

        public bool MayorEdad
        {
            get
            {
                int? laEdadEnAnnos = null;
                bool respuesta = true;
                 
                if (cliente.FechaNacimiento != null)
                {
                    laEdadEnAnnos = (int)((DateTime.Today - (DateTime)cliente.FechaNacimiento).TotalDays / 365.2425);
                }

                if (laEdadEnAnnos <= 6574.365)
                {
                    respuesta = false;
                }

                return respuesta;
            }
        }

        public string Sexo
        {
            get
            {
                string resultado = string.Empty;
                var sexo = cliente.Sexo;

                switch (sexo)
                {
                    case 1:
                        resultado = "Hombre";
                        break;
                    case 2:
                        resultado = "Mujer";
                        break;
                    case null:
                        resultado = "Desconocido";
                        break;
                    default:
                        break;
                }

                return resultado;
            }
        }


    }
}
