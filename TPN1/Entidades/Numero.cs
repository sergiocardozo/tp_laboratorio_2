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
        /// Constructor por defecto 
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (Double.TryParse(strNumero, out retorno))
                return retorno;
            else
                return 0;
        }
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        public Numero (string strNumero)
        {
            SetNumero = strNumero;
        }
        
        //Conversores
        public static string BinarioDecimal(string binario)
        {
            string caracteresPermitidos = "01";
            foreach (char caracter in binario)
            {
                if (!caracteresPermitidos.Contains(caracter))
                    return "Valor Invalido";
            }
            return Convert.ToUInt64(binario, 2).ToString();
        }
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            if (Double.TryParse(numero, out numeroDecimal))
                return DecimalBinario(numeroDecimal);
            else
                return "Valor Invalido";
        }
        public static string DecimalBinario(double numero)
        {
            long sinSigno = Convert.ToInt64(Math.Abs(numero));
            return Convert.ToString(sinSigno, 2);
        }
        
        //Sobrecarga de operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;
            else
                return n1.numero / n2.numero;
        }
    }
}
