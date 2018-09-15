using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double numero = 0;
            string aux;
            aux = ValidarOperador(operador);
                switch (aux)
                {
                    case "+":
                        numero = (num1 + num2);
                        break;
                    case "-":
                        numero = (num1 - num2);
                        break;
                    case "*":
                        numero = (num1 * num2);
                        break;
                    case "/":
                        numero = (num1 / num2);
                        break;
                }
                return numero;
        }

        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }
    }
}

