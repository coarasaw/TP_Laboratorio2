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

        public Numero(string numero)
        {
            SetNumero(numero);
        }

        private void SetNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        public static double ValidarNumero(string NumeroString)
        {
            double numero = 0;

            if (double.TryParse(NumeroString, out numero) == false)
                return 0;
            else
                return numero;
        }

        public static double BinarioDecimal(string numero)
        {
            int i, tam = numero.Length, posicion;
            double Decimal = 0;

            for (i = 1; i <= tam; i++)
            {
                posicion = int.Parse(numero.Substring(tam - i, 1));

                if (posicion == 1)
                    Decimal = Decimal + Math.Pow(2, i - 1);
            }

            return Decimal;
        }

        public static string DecimalBinario(double numero)
        {
            string binario = "";
            while (numero > 1)
            {
                binario = (numero % 2).ToString() + binario;
                numero = (int)numero / 2;
            }
            binario = numero.ToString() + binario;
            return binario;
        }

        
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
    }
}
