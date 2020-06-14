using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Lectura y Escritura de la lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad Lectura y Escritura de la lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura de la lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// Indexador de Jornadas
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Una jornada en especifica</returns>
        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa los atributos de Universidad.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que hace publico los datos de universidad.
        /// </summary>
        /// <returns>El metodo MostrarDatos</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Metodo privado y de clase que muestra los datos de una Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna los datos en formato cadena de caracteres</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada jornada in uni.jornada)
            {
                sb.Append(jornada.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metodo que guardara los datos de la Jornada en un archivo XML.
        /// </summary>
        /// <param name="uni">Universidad a guardar en el archivo</param>
        /// <returns>True si el archivo fue guardado exitosamente.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            return serializador.Guardar(path, uni);
        }
        /// <summary>
        /// Leera desde un archivo una Universidad
        /// </summary>
        /// <returns>retornará un Universidad con todos los datos previamente serializados.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> deserializador = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            Universidad retorno;
            deserializador.Leer(path, out retorno);
            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Una Universidad sera igual a un Alumno si el mismo esta inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Resultado de la comparacion</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Universidad sera distinto a un Alumno si el mismo esta inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Resultado de la comparacion</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Una Universidad sera igual a un Profesor si el mismo esta dando clases en ella.
        /// </summary>
        /// <param name="g">Universidad a verificar</param>
        /// <param name="i">Profesor a verificar</param>
        /// <returns>Resultado de la comparacion</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Universidad sera distinto a un Profesor si el mismo esta dando clases en ella.
        /// </summary>
        /// <param name="g">Universidad a verificar</param>
        /// <param name="i">Profesor a verificar</param>
        /// <returns>Resultado de la comparacion</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Igualacion entre Universidad y Clase
        /// </summary>
        /// <param name="u">Universidad a verificar</param>
        /// <param name="clases">Clase a verificar</param>
        /// <returns>Retornara el primer Profesor capaz de dar la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clases)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clases)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Distinto entre Universidad y Clase
        /// </summary>
        /// <param name="u">Universidad a verificar</param>
        /// <param name="clases">Clase a verificar</param>
        /// <returns>El primer Profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clases)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor != clases)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Adiccion agrega un Alumno a una Universidad validando que no este cargado.
        /// </summary>
        /// <param name="u">Universidad a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Una universidad con un Alumno cargado si es correcto, caso contrario excepcion </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            u.alumnos.Add(a);
            return u;
        }
        /// <summary>
        /// Adiccion agrega un Profesor a una Universidad validando que no este cargado.
        /// </summary>
        /// <param name="u">Universidad a verificar</param>
        /// <param name="i">Profesor a verificar</param>
        /// <returns>Una Universidad con un Profesor si es correctamente cargado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.profesores.Add(i);
            return u;
        }
        /// <summary>
        /// Adiccion agrega una clase a una Universidad.
        /// </summary>
        /// <param name="g">Universidad a verificar</param>
        /// <param name="clases">Clase a verificar</param>
        /// <returns>Una Universidad con su Jornada, Profesor y su lista de Alumnos.</returns>
        public static Universidad operator +(Universidad g, EClases clases)
        {
            Jornada jornada = new Jornada(clases, g == clases);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clases)
                    jornada.Alumnos.Add(alumno);
            }
            g.jornada.Add(jornada);
            return g;
        }
        #endregion

        #region Enumerados
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        #endregion
    }
}
