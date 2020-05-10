using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase derivada de la clase base Vehiculo
    /// </summary>
    public class Camioneta : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// ReadOnly: Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, que inicializa los atributos utilizando la clase base
        /// </summary>
        /// <param name="marca">Marca de la camioneta</param>
        /// <param name="chasis">Chasis de la camioneta</param>
        /// <param name="color">Color de la camioneta</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribe los datos de la clase base y añade el tamaño
        /// </summary>
        /// <returns>Retorna el mensaje en string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
