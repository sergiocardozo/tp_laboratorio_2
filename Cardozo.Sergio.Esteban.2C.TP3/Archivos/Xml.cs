using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Guarda un dato en un archivo serializado como xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true si se guardo correctamente, caso contrario lanza una excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter write = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(write, datos);
                }
                return true;
            }
            catch (Exception exception)
            {

                throw new ArchivosException(exception);
            }
        }
        /// <summary>
        /// Lee un tipo de dato a partir de un archivo xml
        /// </summary>
        /// <param name="archivo">Direccion del archivo</param>
        /// <param name="datos">Datos que se leyeron</param>
        /// <returns>Retorna true si se leyo con exito, caso contrario lanza una excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                }
                return true;
            }
            catch (Exception exception)
            {

                throw new ArchivosException(exception);
            }
        } 
        #endregion

    }
}
