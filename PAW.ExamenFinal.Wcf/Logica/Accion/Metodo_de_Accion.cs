using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAW.ExamenFinal.Wcf.Logica.Accion
{
    public class Metodo_de_Accion
    {
        public ModelDB.Cliente IdentificarCliente(int idCliente)
        {
            var elRepositorio = new Logica.Metodo_De_Repositorio.Clientes();
            var elResultado = elRepositorio.IdentificarCliente(idCliente);
            return elResultado;
        }
    }
}