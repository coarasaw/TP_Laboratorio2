using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base()
        { }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        { }
    }
}
