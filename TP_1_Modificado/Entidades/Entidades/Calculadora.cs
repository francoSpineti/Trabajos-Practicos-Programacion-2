using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>Funcion que valida los operadores aritmeticos.
        /// </summary>
        /// <param name="operador">String operador</param>
        /// <returns>retorna el operador seleccionado, sino por defecto retorna el operador + .</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }

        /// <summary>Funcion que realizara la suma,resta,multiplicacion o division entre 2 numeros
        /// </summary>
        /// <param name="numero1">Numero numero1</param>
        /// <param name="numero2">Numero numero2</param>
        /// <param name="operador">String operador</param>
        /// <returns>depende del operador que le llegue a la funcion, retornara la opcion indicada.</returns>
        public static double OperarCalculadora(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = numero1 + numero2;
                    break;

                case "-":
                    retorno = numero1 - numero2;
                    break;

                case "*":
                    retorno = numero1 * numero2;
                    break;

                case "/":
                    retorno = numero1 / numero2;
                    break;
            }
            return retorno;
        }
    }
}
