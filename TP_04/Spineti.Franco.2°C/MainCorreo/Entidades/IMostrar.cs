using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public interface IMostrar<T>
    {
        /// <summary>Va a mostrar los datos del tipo que reciba la funcion.
        /// </summary>
        /// <param name="elemento">elemento</param>
        /// <returns></returns>
         string MostrarDatos(IMostrar<T> elemento);
    }
}
