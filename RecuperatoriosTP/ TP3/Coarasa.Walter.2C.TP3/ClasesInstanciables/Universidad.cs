using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornadas; }
            set { jornadas = value; }
        }

        public Jornada this[int i]
        {
            get { return jornadas[i]; }
            set { jornadas[i] = value; }
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool esta = false;
            foreach (Alumno elemento in g.alumnos)
            {
                if (elemento == a)
                {
                    esta = true;
                    break;
                }
            }
            return esta;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool esta = false;
            foreach (Profesor elemnto in g.profesores)
            {
                if (elemnto == i)
                {
                    esta = true;
                    break;
                }
            }
            return esta;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            else 
            {
                throw new SinProfesorException("No hay Profesor para la clase");
            }
            return u;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinProfesorException("No hay Profesor para la clase");
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item != clase)
                    return item;
            }
            throw new SinProfesorException("No hay Profesor para la clase");
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada jornada = new Jornada(clase, p); 

            if (!(Object.Equals(p, null)))
            {
                jornada = new Jornada(clase, p);
            }
            else
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            if (!(Object.Equals(jornada, null)))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == clase)
                        jornada.Alumnos.Add(item); 
                }
               g.Jornadas.Add(jornada);
            }
            return g;
        }

        private string MostarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();
            
            datos.AppendLine("Jornada ");
            foreach (Jornada item in uni.jornadas)
            {
                datos.AppendLine(item.ToString());
            }
            return datos.ToString();
        }

        public override string ToString()
        {
            return MostarDatos(this);
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> dato = new Xml<Universidad>();
            return dato.Guardar("Universidad.xml", uni);
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }   
}
