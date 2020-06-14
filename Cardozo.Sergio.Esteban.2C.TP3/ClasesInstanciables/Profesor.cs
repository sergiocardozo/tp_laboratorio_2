using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico que inicializa el atributo estatico random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor que inicializa un Profesor tomando como base al constructor de Universitario
        /// </summary>
        /// <param name="id">Legajo del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega una clase aleatoria a la cola
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            Thread.Sleep(300);
        }
        /// <summary>
        /// Metodo que devuelve la clase que da el profesor
        /// </summary>
        /// <returns>Retornada una cadena de string.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metodo protegido que muestra los datos del Profesor
        /// </summary>
        /// <returns>Retornada los datos.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Metodo que hara publico los datos del Profesor
        /// </summary>
        /// <returns>Cadena de texto con los datos.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Un profesor sera igual a una clase si da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a comprobar</param>
        /// <returns>Resultado de la comparacion.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Comprueba si un Profesor da una clase de una materia especifica
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a comprobar.</param>
        /// <returns>Resultado de la comparacion.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
