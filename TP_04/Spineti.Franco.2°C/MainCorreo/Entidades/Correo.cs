using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades

        public List<Paquete> Paquetes
        {
            get { return this.paquetes;}
            set { this.paquetes = value;}
        }

        #endregion

        #region Metodos

        /// <summary>
        /// constructor sin parametros que inicia las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Finaliza los hilos que quedaron con vida.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }          
        }

        /// <summary>
        /// Muestra los datos del paquete.
        /// Casteo el elemento a correo y accedo a los datos.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            Correo lista = (Correo)elemento;

            if(elemento is Correo)
            {
                foreach (Paquete aux in lista.Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})\n", aux.TrackingID, aux.DireccionEntrega,
                    aux.Estado.ToString());
                }
            }
            return sb.ToString();
        }

        #endregion

        #region Operador +

        /// <summary>
        ///Verifica que el tracking id no se repita, si no son iguales los agrega a la lista de paquetes.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete aux in c.Paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("El id ya se encuentra en la lista");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }

        #endregion
    }
}
