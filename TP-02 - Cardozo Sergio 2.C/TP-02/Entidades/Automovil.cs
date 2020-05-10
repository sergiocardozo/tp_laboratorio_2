using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase derivada de la clase base Vehiculo
    /// </summary>
    public class Automovil : Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerado que indica el tipo de auto.
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }
        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: retorna el tamaño del automovil en mediano.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">marca del automovil</param>
        /// <param name="chasis">numero de chasis del automovil</param>
        /// <param name="color">Color del automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.Monovolumen)
        {
        }
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base y el tipo de automovil.
        /// </summary>
        /// <param name="marca">marca del automovil</param>
        /// <param name="chasis">numero de chasis del automovil</param>
        /// <param name="color">color del automovil</param>
        /// <param name="tipo">tipo de automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribe los datos de la clase base, añade el tamaño y el tipo de automovil.
        /// </summary>
        /// <returns>Retorna el mensaje en string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.Append(string.Format("TAMAÑO: {0}", this.Tamanio));
            sb.Append(string.Format(" TIPO: {0}\n", this.tipo));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion

    }
}
