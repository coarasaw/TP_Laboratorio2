﻿using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base(innerException.Message)
        { }
    }
}
