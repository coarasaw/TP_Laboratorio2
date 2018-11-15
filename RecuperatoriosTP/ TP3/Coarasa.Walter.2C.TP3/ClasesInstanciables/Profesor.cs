using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDeDia;
        static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad naconalidad)
            : base(id, nombre, apellido, dni, naconalidad)
        {
            clasesDeDia = new Queue<Universidad.EClases>();
            clasesDeDia.Enqueue((Universidad.EClases)random.Next(1, 4));
            clasesDeDia.Enqueue((Universidad.EClases)random.Next(1, 4));
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Clasel del día ");
            foreach (Universidad.EClases item in this.clasesDeDia)
            {
                datos.AppendLine(item.ToString());
            }
            return datos.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool siDaClase = false;
            foreach (Universidad.EClases item in i.clasesDeDia)
            {
                if (item == clase)
                {
                    siDaClase = true;
                }
            }
            return siDaClase;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
