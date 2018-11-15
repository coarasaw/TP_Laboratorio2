using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
        { }

        public DniInvalidoException(Exception e) : base(e.Message)
        { }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {
            this.mensajeBase = mensaje;
        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            this.mensajeBase = mensaje;
        }
    }
}
