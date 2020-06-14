using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Lectura y Escritura de Apellido. Lo valida antes de ingresar
        /// </summary>
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.apellido = value;
            }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura de DNI. Lo valida antes de ingresar
        /// </summary>
        public int DNI
        {
            get { return dni; }
            set
            {
                dni = ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura de la Nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { this.nacionalidad = value; }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura del nombre de la persona. Lo valida antes de ingresar
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.nombre = value;
            }
        }
        /// <summary>
        /// Propiedad solo Escritura del DNI. Lo valida antes de ingresarlo
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor atributos por default
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor inicializa el nombre, apellido y nacionalidad de una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor inicializa el nombre, apellido, el dni numerico y nacionalidad de una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor inicializa nombre, apellido, dni en caracteres y nacionalidad de una persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del metodo ToString hace publico todos los datos de una persona.
        /// </summary>
        /// <returns>Retorna todos los datos de una persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}"));
            sb.AppendLine(string.Format($"NACIONALIDAD: {this.Nacionalidad}"));
            return sb.ToString();
        }
        /// <summary>
        /// Validacion del atributo dni en tipo int
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI a comprobar</param>
        /// <returns>Retorna el dni si es valido, caso contrario lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato > 89999999)
                throw new NacionalidadInvalidaException();
            if (nacionalidad == ENacionalidad.Extranjero && dato < 90000000)
                throw new NacionalidadInvalidaException();
            if (dato < 1 || dato > 99999999)
                throw new DniInvalidoException();
            return dato;
        }
        /// <summary>
        /// Validacion de atributo dni en tipo string
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI a comprobar</param>
        /// <returns>Retorna el DNI si es valido, caso contrario lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            if (!Int32.TryParse(dato, out int dni))
                throw new DniInvalidoException();
            else
                return ValidarDni(nacionalidad, dni);
        }
        /// <summary>
        /// Valida los atributos nombre y apellido de tipo string
        /// </summary>
        /// <param name="dato">Texto a corroborar</param>
        /// <returns>Retorna el atributo si es valido, caso contrario retornara null</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!(char.IsLetter(item) || char.IsWhiteSpace(item)))
                    return null;
            }
            return dato;
        }
        #endregion
    }
}