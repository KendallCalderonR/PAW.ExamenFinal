using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.ExamenFinal.ModelDB;

namespace PAW.ExamenFinal.ModelDB.MisTablas
{
    public partial class Renta
    {

        Renta renta = new Renta();



        public DateTime FechaRenta
        {
            get {
                DateTime rentdate = DateTime.Now;

                return rentdate;
            }

        }
        public DateTime FechaDebeDevolver {

            get {
                // dandole 7 dias de gracia
                DateTime returndate = FechaRenta.AddDays(7);
                return returndate;
            }

        }
        public Double TotalDiasAtraso {

        get {
                DateTime returnexpected = renta.FechaDebeDevolver;
                DateTime returnReal = renta.;
                DateTime returntotaldelay = DateTime.Now;
                Double totaldays = 0.0;
                if (returnexpected < returnReal) {
                  
                    totaldays = (returnexpected - returnReal).TotalDays;

                    returntotaldelay = returnexpected;


                }
                return totaldays;

            }
        }
   
        public bool PeliculaDevuelta  {
            get {

                bool returned = false;
                
                if (renta.PeliculaDevuelta) {
                    returned = true;               
                }
                else { returned = false; }

                return returned;

            }
        }
        
        public int IDCliente;
        public int IDCopiaPelicula;

    }
}
