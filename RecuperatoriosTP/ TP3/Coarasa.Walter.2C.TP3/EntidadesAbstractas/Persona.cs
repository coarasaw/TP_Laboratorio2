using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        public int DNI
        {
            get { return this.dni; }
            set
            {
                this.dni = ValidarDni(nacionalidad, value);
            }
        }

        public string StringToDni
        {
            set
            {
                DNI = ValidarDni(nacionalidad, value);
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int volverValor = 0;
           
            if (ENacionalidad.Argentino == nacionalidad)
            {
                if (dato > 1 && dato < 89999999)
                {
                    volverValor = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La Nacionalidad no se condice conel número de DNI");
                }
            }
            else
            {
                if (dato > 90000000 && dato < 99999999)
                {
                    volverValor = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La Nacionalidad no se condice conel número de DNI");
                }
            }
            return volverValor;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            Regex reg = new Regex("[0-9]"); //Expresión que solo acepta números.
            bool esNumero = reg.IsMatch(dni.ToString()); //En este caso obtendríamos true, ya que el string esta conformado solo por números.
            if (esNumero)
            {
                return int.Parse(dato);
            }
            else
            {
                throw new DniInvalidoException("Error: Formato DNI");
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                Regex reg = new Regex("[a-zA-Z]"); //Expresión que solo acepta Letras  [a-zA-Z]
                bool esLetra = reg.IsMatch(nombre); //En este caso obtendríamos true, ya que el string esta conformado solo por letras. 
                if (esLetra)
                {
                    this.nombre = value;
                }
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                Regex reg = new Regex("[a-zA-Z]"); //Expresión que solo acepta Letras  [a-zA-Z]
                bool esLetra = reg.IsMatch(apellido); //En este caso obtendríamos true, ya que el string esta conformado solo por letras. 
                if (esLetra)
                {
                    this.apellido = value;
                }
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDni = dni;
        }

        //Devuelve los datos de Personas
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("Nombre Completo " + this.Apellido + ", " + this.Nombre );
            datos.AppendLine("DNI " + dni);
            datos.AppendLine("Nacionalidad " + this.Nacionalidad);
            return datos.ToString();
        }
    }
}