using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        protected int legajo;

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        // Devuelve los datos de Universitario
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.ToString());
            datos.AppendLine("Legajo Numero " + this.legajo);
            return datos.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1 is Universitario && pg2 is Universitario) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
