using System;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<V> : IArchivo<V>
    {
        public bool Guardar(string archivo, V datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public bool Leer(string archivo, out V datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                XmlTextReader writer = new XmlTextReader(archivo);
                datos = (V)serializer.Deserialize(writer);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
