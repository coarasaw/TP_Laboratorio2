using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto //no es sealed
    {
        public enum EMarca // enum debe ser public
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;

        //Agrego el contructor con 3 parametros
        public Producto(string codigo,EMarca marca,ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; } // tiene que ser protected para que la clase herede pueda implementar NO va set;

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar() //no puede ser sealed, sino public y virtual
        {
            return (string)this; //Conversion explicita
        }

        public static explicit operator string(Producto p) //debe ser public en lugar de private
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p.codigoDeBarras);          //{0}\r\n",  Se reemplaza por " + 
            sb.AppendLine("MARCA          :  " + p.marca.ToString());        //{0}\r\n",  Se reemplaza por " +
            sb.AppendLine("COLOR EMPAQUE  : " + p.colorPrimarioEmpaque.ToString()); //{0}\r\n", Se reemplaza por " +
            sb.AppendLine("---------------------");

            return sb.ToString(); //Falta ToString()
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
