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

        /// <summary>
        /// Propiedad. Inicializa un objeto del tipo numero y valida que sea correcto.
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        #region Constructores
        /// <summary>
        /// Constructor por defecto, instancia el objeto del tipo numero en cero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Inicializa una instancia del tipo Numero recibiendo un numero del tipo double.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa una instancia del tipo Numero recibiendo un string validando que sea un valor correcto.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        /// <summary>
        /// Metodo de clase que comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el valor recibido en formato double, caso contrario retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (Double.TryParse(strNumero, out retorno))
                return retorno;
            else
                return 0;
        }

        #region Conversores
        /// <summary>
        /// Convierte un dato de tipo string a un string en Decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el resultado si es correcto, caso contrario retornara "Valor Invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            string caracteresPermitidos = "01";
            foreach (char caracter in binario)
            {
                if (!caracteresPermitidos.Contains(caracter))
                    return "Valor Inválido";
            }
            return Convert.ToUInt64(binario, 2).ToString();
        }
        /// <summary>
        /// Convierte un dato de tipo string a un string en Binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el resultado si logra hacer la conversion, caso contrario retorna "Valor invalido".</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            if (Double.TryParse(numero, out numeroDecimal))
                return DecimalBinario(numeroDecimal);
            else
                return "Valor Inválido";
        }
        /// <summary>
        /// Convierte un dato del tipo double a un string binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el resultado de la conversion.</returns>
        public static string DecimalBinario(double numero)
        {
            long sinSigno = Convert.ToInt64(Math.Abs(numero));
            if (numero > 0)                
                return Convert.ToString(sinSigno, 2);
            else
                return "Valor Inválido";
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Metodo estatico suma dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la suma de los atributos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Metodo estatico resta dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la resta de los atributos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Metodo estatico multiplica dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicacion de los atributos.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Metodo estatico divide dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Si el segundo operando es igual a 0 retorna el menor valor posible de un double,
        /// caso contrario retorna el resultado de la division.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;
            else
                return n1.numero / n2.numero;
        }
        #endregion
    }
}
