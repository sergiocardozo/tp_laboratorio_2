using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        #region MetodoDeExtension
        /// <summary>
        /// Metodo de extension que guardara en el escritorio el contenido de un objeto
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre archivo</param>
        /// <returns>Retorna true si se guardo correctamente el archivo</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                using (StreamWriter writer = new StreamWriter(path + "\\" + archivo, true))
                {
                    writer.WriteLine(texto);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion
    }
}
