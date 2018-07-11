using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Numero
    {
        private double numero;

        #region Constructores y Set

        /// <summary>Constructor vacio.
        /// </summary>
        public Numero()
        {

        }

        /// <summary>Funcion que setea el numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>Funcion que setea el numero y validando que no sean letras.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        /// <summary>
        /// Propiedad que asigna valor al atributo numero.
        /// </summary>
        /// <returns>Valor ingresado en formato double</returns>
        public string SetNumero
        {
            set
            {
                double aux = ValidarNumero(value);
                if (aux != 0)
                    this.numero = aux;
            }
        }
        
        #endregion

        #region Operadores (+,-,*,/)

        /// <summary>Funcion que realiza la suma de 2 numeros
        /// </summary>
        /// <param name="n1">Numero n1</param>
        /// <param name="n2">Numero n2</param>
        /// <returns>retorna la suma de ambos numeros.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = n1.numero + n2.numero;
            return retorno;
        }

        /// <summary>Funcion que realiza la resta de 2 numeros 
        /// </summary>
        /// <param name="n1">Numero n1</param>
        /// <param name="n2">Numero n2</param>
        /// <returns>retorna la resta de ambos numeros.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = n1.numero - n2.numero;
            return retorno;
        }

        /// <summary>Funcion que realiza la division de 2 numeros
        /// </summary>
        /// <param name="n1">Numero n1</param>
        /// <param name="n2">Numero n2</param>
        /// <returns>retorna la division de ambos numeros.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = n1.numero / n2.numero;
            return retorno;
        }

        /// <summary>Funcion que realiza la multiplicacion de 2 numeros
        /// </summary>
        /// <param name="n1">Numero n1</param>
        /// <param name="n2">Numero n2</param>
        /// <returns>retorna la multiplicacion de ambos numeros.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = n1.numero * n2.numero;
            return retorno;
        }

        #endregion

        #region Metodos

        /// <summary> Funcion que transforma un numero binario a decimal
        /// </summary>
        /// <param name="numero"> string numero</param>
        /// <returns>retorna el numero que se ingreso en decimal</returns>
        public static string BinarioDecimal(string numero)
        {
            int nroDecimal = 0, aux = 0;
            string retorno = "";

            for (int i = 1; i <= numero.Length; i++)
            {
                if (Int32.TryParse(numero[i - 1].ToString(), out aux) && (aux == 1 || aux == 0))
                {
                    nroDecimal += aux * (int)Math.Pow(2, numero.Length - i);
                    retorno = nroDecimal.ToString();
                }
                else
                    retorno = "Valor invalido";
            }
            return retorno;
        }

        /// <summary> Funcion que convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numero">Double numero</param>
        /// <returns>retorna el numero decimal transformado a binario</returns>
        public static String DecimalBinario(double numero)
        {
            string binario = "";
            int entero = (int)numero;
            while (entero >= 2)
            {
                binario = (entero % 2).ToString() + binario;
                entero = (int)entero / 2;
            }
            return entero.ToString() + binario;
        }

        /// <summary> Funcion que convierte un numero Decimal a Binario
        /// </summary>
        /// <param name="numero">String numero</param>
        /// <returns>retorna el numero que recibe por parametro en binario.</returns>
        public static String DecimalBinario(string numero)
        {
            double retorno = 0;

            if (Double.TryParse(numero, out retorno))
                return DecimalBinario(retorno);
            else
                return "Numero invalido";
        }

        /// <summary>Funcion que valida que el numero ingresado sea numerico y lo retornara en double.
        /// Caso contrario retornara 0.
        /// </summary>
        /// <param name="strNumero">string strNumero</param>
        /// <returns>retorna el valor en double o por defecto 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (double.TryParse(strNumero, out retorno))
                return retorno;
            else
                return 0;
        }
       
        #endregion

    }
}
