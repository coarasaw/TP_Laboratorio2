using System.Text;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        //Reescribo metodo para mostrar datos de Alumnos
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine("Estado de Cuenta " + this.estadoCuenta);
            datos.AppendLine(this.ParticiparEnClase());
            //datos.AppendLine("Alumnos: ");
            //datos.AppendLine(base.legajo.ToString());
            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "Toma Clase de " + this.claseQueToma + "\n";
        }

        public static bool operator ==(Alumno a, Universidad.EClases clases)
        {
            return (a.claseQueToma == clases && EEstadoCuenta.AlDia == a.estadoCuenta);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clases)
        {
            return !(a == clases);
        }

        public override string ToString()
        {
            //return (claseQueToma.ToString() + estadoCuenta.ToString());
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
   
}
