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

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>Funcion del boton Cerrar que cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>Funcion del boton Convertir a Binario que transforma el resultado en un numero binario si se puede.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text.Contains(",") || lblResultado.Text.Contains("-") || lblResultado.Text == "")
                MessageBox.Show("No se puede convertir el resultado a binario.");
            else
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        /// <summary>Funcion del boton Convertir a Decimal que transforma el resultado en un numero decimal si se puede.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnConverADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text.Contains(",") || lblResultado.Text.Contains("-") || lblResultado.Text == "")
                MessageBox.Show("No se puede convertir el resultado a binario.");
            else
            {
                Numero num1 = new Numero();
                lblResultado.Text = Convert.ToString(Numero.BinarioDecimal(lblResultado.Text));
            }
        }

        /// <summary>Funcion del boton Limpiar que llama a la funcion privada Limpiar
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>Funcion del boton Operar que llama a la funcion privada Operar
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double result = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = Convert.ToString(result);
        }

        /// <summary>Funcion que limpia los campos de la calculadora.
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedItem = null;
        }

        /// <summary>Funcion que recibe por parametros los numeros y el operador y realiza la operacion correspondiente entre ambos numeros.
        /// </summary>
        /// <param name="numero1">numero1</param>
        /// <param name="numero2">numero2</param>
        /// <param name="operador">operador</param>
        /// <returns>Retorna el resultador de la operacion</returns>
        private double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            if (numero2 == "0" && operador == "/")
            {
                MessageBox.Show("ERROR, NO SE PUEDE DIVIDIR POR CERO");
                return 0;
            }
            else
                return Calculadora.OperarCalculadora(num1, num2, operador);
            
        }

        /// <summary>Funcion que valida que solamente se permitan numeros en vez de letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCaracter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {
        
        }
    }
}
