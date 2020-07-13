using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        #region Enumerados
        public enum EEstado { Ingresado, EnViaje, Entregado }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Lectura y Escritura de la Direccion de Entrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura del ID del paquete
        /// </summary>
        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura del Estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor que inicializa los atributos
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que va a cambiar el estado de los paquetes y guardarlos en SQL
        /// </summary>
        public void MockClicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformarEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);

        }
        /// <summary>
        /// Metodo que va a mostrar la informacion del paquete
        /// </summary>
        /// <param name="elemento">Elemento a mostrar</param>
        /// <returns>Retorna la cadena de caracteres</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format($"{this.TrackingID} para {this.DireccionEntrega}");
        }
        /// <summary>
        /// Muestra la informacion del paquete
        /// </summary>
        /// <returns>Retornara la informacion del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Conversores
        /// <summary>
        /// Dos paquetes seran iguales si su TrackingID es igual.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Dos paquetes seran distintos si su TrackingID es distinto.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        } 
        #endregion

    }
}
