using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>Constructor que recibe un mensaje.
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>Constructor que recibe un mensaje y una Excepcion, sobrecarga el primer constructor.
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="inner">inner</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base (mensaje,inner)
        { }

    }
}
