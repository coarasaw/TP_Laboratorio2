using System.Collections.Generic;
using System.Text;
using Archivos;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.Clase);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if ((j != a))
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder dato = new StringBuilder();
            dato.AppendLine("Clase de " + this.Clase);
            dato.AppendLine(this.Instructor.ToString());
            dato.AppendLine("Alumnos ");
            foreach (Alumno item in this.Alumnos)
            {
                dato.AppendLine(item.ToString());
            }
            dato.AppendLine("---------------------");
            return dato.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }
    }
}
