using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerado con las marcas de los vehiculos
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        /// <summary>
        /// Enumerado con el tamaño del vehiculo.
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Atributos
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;
        #endregion

        #region Propiedad
        /// <summary>
        /// ReadOnly: Retornará el tamaño del vehiculo
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa los atributos de la clase
        /// </summary>
        /// <param name="chasis">Numero de chasis</param>
        /// <param name="marca">Marca del auto</param>
        /// <param name="color">Color del auto</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retorna el vehiculo con todos sus datos convertido en string</returns>        
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Conversor
        /// <summary>
        /// Publica todos los datos del producto y los retorna.
        /// </summary>
        /// <param name="p">Atributo que va a exponer.</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"CHASIS: {p.chasis}\r"));
            sb.AppendLine(string.Format($"MARCA : {p.marca}\r"));
            sb.AppendLine(string.Format($"COLOR : {p.color}\r"));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna dos vehiculos iguales por su chasis.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna si sus chasis no son iguales reutilizando codigo</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}
