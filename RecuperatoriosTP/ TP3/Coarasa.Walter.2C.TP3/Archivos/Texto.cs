using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    file.Write(datos);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadLine();
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
