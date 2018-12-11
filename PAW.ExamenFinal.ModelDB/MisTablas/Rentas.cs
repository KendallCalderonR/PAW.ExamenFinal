using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.ExamenFinal.ModelDB;

namespace PAW.ExamenFinal.ModelDB.MisTablas
{
    public partial class Rentas
    {

        Renta renta = new Renta();
        


        public DateTime? FechaRenta
        {
            get {
                DateTime? rentdate = renta.FechaRenta;

                return rentdate;
            }
            set { DateTime rentdate = DateTime.Now; }
        }
        public bool FechaDevolucionValidacion {

            get {
                
                DateTime? returndate = renta.FechaDebeDevolver;
                DateTime? returneddatereal = renta.FechaDevolucion;

                double daysbetween = DateTime.Compare((DateTime)returneddatereal, (DateTime)returndate);

                bool latemorethan = false;

                if (returndate > returneddatereal && daysbetween >= 15) {
                    latemorethan = true;
                }
                
                return latemorethan;
            }
          
        }
        public Double TotalDiasAtraso {

        get {
                DateTime? returnexpected = renta.FechaDebeDevolver;
                DateTime? returnReal = renta.FechaDevolucion;
                Double unreturnedtotaldays = 0.0;
                if (returnexpected < returnReal) {

                    unreturnedtotaldays = (returnexpected - returnReal).TotalDays;
                    
                }
                return unreturnedtotaldays;

            }
        }
   
        public bool PeliculaDevuelta  {
            get {

                bool returned = false;
                
                if ((renta.FechaDevolucion).HasValue) {
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
