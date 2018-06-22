using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// Agrega un paquete al correo y va cambiando el estado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtBoxDireccion.Text != "" && maskedTextBoxTrackingID.Text != "")
            {
                Paquete paquete = new Paquete(txtBoxDireccion.Text, maskedTextBoxTrackingID.Text);
                paquete.InformaEstado += paq_InformaEstado;
                try
                {
                    correo += paquete;
                    ActulizarEstado();
                }
                catch (TrackingIdRepetidoException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Favor de Completar los 2 campos");            
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Actualiza los estados de los paquetes
        /// </summary>
        private void ActulizarEstado()
        {
            listBoxIngresado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            listBoxEntregado.Items.Clear();

            foreach (Paquete aux in correo.Paquetes)
            {
                switch (aux.Estado)
                { 
                    case Paquete.EEstado.Ingresado:
                        listBoxIngresado.Items.Add(aux);
                        break;
                    case Paquete.EEstado.EnViaje:
                        listBoxEnViaje.Items.Add(aux);
                        break;
                    case Paquete.EEstado.Entregado:
                        listBoxEntregado.Items.Add(aux);
                        break;                
                }
            }
        }

        /// <summary>
        /// Carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo que informa el estado del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActulizarEstado();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento is Correo)
                {
                    richTextBoxMostrar.Text = elemento.MostrarDatos(elemento);
                }
                if (elemento is Paquete)
                {
                    richTextBoxMostrar.Text = ((Paquete)elemento).ToString();
                }
            }
            // creo archivo txt en el escritorio
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"salida.txt");
            richTextBoxMostrar.Text.Guardar(filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
          this.MostrarInformacion<Paquete>((IMostrar<Paquete>)listBoxEntregado.SelectedItem);
        }

        /// <summary>
        /// Cierra todos los hilos .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

    }
}
