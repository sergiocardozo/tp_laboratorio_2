using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #endregion

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Constructor que inicializa la clase que toma el Alumno utilizando la clase base.
        /// </summary>
        /// <param name="id">Legajo del Alumno</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Sobrecarga de constructor que inicializa el estado de cuenta del Alumno. 
        /// </summary>
        /// <param name="id">Legajo del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del metodo que muestra los datos del Alumno
        /// </summary>
        /// <returns>Retorna los datos en string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.MostrarDatos()}");
            string cuenta = "";
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    cuenta = "Cuota Al Dia";
                    break;
                case EEstadoCuenta.Deudor:
                    cuenta = "Deudor";
                    break;
                case EEstadoCuenta.Becado:
                    cuenta = "Becado";
                    break;
            }
            sb.AppendLine(string.Format($"ESTADO DE CUENTA: {cuenta}"));
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga metodo abstracto y retorna en que clase participa el Alumno.
        /// </summary>
        /// <returns>Retorna la clase que toma el Alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format($"TOMA CLASES DE {this.claseQueToma}");
        }
        /// <summary>
        /// Sobrecarga el metodo ToString haciendo publicos los datos del alumno
        /// </summary>
        /// <returns>Retorna todos los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
        #region Operadores
        /// <summary>
        /// Comprueba si un Alumno toma una clase Determinada y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna true si el alumno toma esa clase y su estado no es deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Comprueba si el Alumno no toma una clase determinada
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna true si el Alumno no toma la clase</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion
    }
}
