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

        #region Constructor y Sets


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
            double conversion;
            if (double.TryParse(numero, out conversion))
                this.numero = conversion;
        }

        public string SetNumero
        {
            set
            {
                string str = Convert.ToString(this.numero);
                this.numero = ValidarNumero(str);
            }
        }


        #endregion

        #region Operadores (+,-,*,/,binario a decimal,decimal a binario)

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


        /// <summary> Funcion que transforma un numero binario a decimal
        /// </summary>
        /// <param name="numero"> string numero</param>
        /// <returns>retorna el numero que se ingreso en decimal</returns>
        public double BinarioDecimal(string numero)
        {
            int bl = numero.Length;
            double Decimal = 0;

            for (int i = 1; i <= bl; i++)
            {
                byte n = byte.Parse(numero.Substring(bl - i, 1));
                if (n == 1)
                    Decimal += System.Math.Pow(2, i - 1);
                else
                    if (n != 0)
                    {
                        Decimal = 0;
                        return Decimal;
                    }
            }
            return Decimal;
        }


        /// <summary> Funcion que convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numero">Double numero</param>
        /// <returns>retorna el numero decimal transformado a binario</returns>
        public String DecimalBinario(double numero)
        {
            string binario = "";
            while(numero >= 2)
            {
                binario = (numero % 2).ToString()+binario;
                numero = (int)numero/2;
            }
            return numero.ToString()+binario;
        }


        /// <summary> Funcion que convierte un numero Decimal a Binario
        /// </summary>
        /// <param name="numero">String numero</param>
        /// <returns>retorna el numero que recibe por parametro en binario.</returns>
        public String DecimalBinario(string numero)
        {
            int num = Convert.ToInt32(numero);
            String binario = "";

            if (num > 0)
                while (num > 0)
                {
                    if (num % 2 == 0)
                        binario = "0" + binario;
                    else
                        binario = "1" + binario;
                    num = (int)num / 2;
                }
            else
                if (num == 0)
                    binario = "0";
            return binario;
        }

        #endregion

        #region Validaciones

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
