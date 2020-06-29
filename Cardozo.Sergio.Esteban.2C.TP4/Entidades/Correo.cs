using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// 
        /// propiedad Lectura y Escritura de la Lista de Paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { this.paquetes = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa atributos
        /// </summary> 
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que va a finalizar los hilos que esten en ejecucion
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread thread in this.mockPaquetes)
            {
                if (thread != null && thread.IsAlive)
                    thread.Abort();
            }
        }
        /// <summary>
        /// Metodo que va a mostrar los datos de un paquete
        /// </summary>
        /// <param name="elementos">Elementos que tiene ese paquete</param>
        /// <returns>Retorna la cadena de caracteres</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in this.Paquetes)
            {
                sb.AppendLine(string.Format($"{p.TrackingID} para {p.DireccionEntrega} ({p.Estado.ToString()})"));
            }
            return sb.ToString();
        }
        #endregion

        #region Conversores
        /// <summary>
        /// Agrega un paquete a la lista verificando que no exista
        /// </summary>
        /// <param name="c">Correo a verificar</param>
        /// <param name="p">Paquete a verificar</param>
        /// <returns>Retorna el correo con el paquete si no lanza una excepcion</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista");
            }
            c.Paquetes.Add(p);
            Thread thread = new Thread(p.MockClicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        } 
        #endregion
    }
}
