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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

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

        public string BinarioDecimal(string binario)
        {
            string numeroBinario = "01";

            foreach( char array in binario)
            {
                if (numeroBinario.Contains(array))
                    return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor invalido";
        }

        public string DecimalBinario(double numero)
        {
            long sinSigno;
            sinSigno = Convert.ToInt64(Math.Abs(numero));
            return Convert.ToString(sinSigno, 2);
        }

        public string DecimalBinario(string numero)
        {
            double numeroDecimal;
            if (double.TryParse(numero, out numeroDecimal))
                return DecimalBinario(numeroDecimal);
            else
                return "Valor invalido";
        }

        //Sobrecarga de metodos

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1,Numero n2)
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
