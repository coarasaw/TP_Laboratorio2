using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string patente, ConsoleColor color):base(patente,marca,color) // Falta pasar los parametros al constructor de Producto
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias //Falta override ya que hereda de Producto
        {
            get
            {
                return 80;
            }
        }

        public override sealed string Mostrar() //modificador de acceso no puede cambiar al heredado
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar()); // cambio el this por base asi no se llama asi mismo
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias); //{0}", se reemplaza por "+
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); // Falta .ToString() 
        }
    }
}
