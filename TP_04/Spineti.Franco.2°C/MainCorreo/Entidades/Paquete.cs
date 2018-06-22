using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
  
        #endregion

        #region Metodos

        /// <summary>Constructor con dos parametros.
        /// </summary>
        /// <param name="direccionEntrega">direccionEntrega</param>
        /// <param name="trackingID">trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Cambia el estado del paquete de 10 segundos y lo guarda en la BD.
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);
                
                if(Estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje ;
                }
                else
                {
                    this.estado = EEstado.Entregado;     
                }
                InformaEstado(this, new EventArgs());

            } while (Estado != EEstado.Entregado);
            PaqueteDAO.Insertar(this);
        }

        /// <summary>Muestra todos los datos del Paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>Muestra el ID y la direccion de entrega
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID,((Paquete)elemento).DireccionEntrega);          
        }

        #endregion

        #region Operadores

        /// <summary>Verifica que dos Paquetes sean iguales siempre y cuando el ID sea el mismo.
        /// </summary>
        /// <param name="p1">p1</param>
        /// <param name="p2">p2</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>Verifica que dos Paquetes sean distintos.
        /// </summary>
        /// <param name="p1">p1</param>
        /// <param name="p2">p2</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Enumerador

        public enum EEstado
        { 
            Ingresado,
            EnViaje,
            Entregado
        }

        #endregion

        #region Delegados y Eventos

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;

        #endregion

    }
}
