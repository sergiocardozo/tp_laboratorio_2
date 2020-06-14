using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura de la Lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad lectura y escritura del enumerado Clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return clase; }
            set { this.clase = value; }
        }
        /// <summary>
        /// Propiedad lectura y escritura de la clase Profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado que inicializa la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor que inicializa una clase y un profesor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que guardara los datos de la Jornada en un archivo .txt
        /// </summary>
        /// <param name="jornada">Jornada a guardar en el archivo.</param>
        /// <returns>Retornara el archivo si fue guardado exitosamente(True).</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivador = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            return archivador.Guardar(path, jornada.ToString());
        }
        /// <summary>
        /// Leera desde un archivo una Jornada
        /// </summary>
        /// <returns>Retornara los datos de la Jornada como texto</returns>
        public static string Leer()
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            archivo.Leer(path, out string datos);
            return datos;
        }
        /// <summary>
        /// Metodo que mostrara los datos de una Jornada
        /// </summary>
        /// <returns>Retornara los datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format($"CLASE DE {this.clase.ToString()} POR {this.instructor}"));
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in alumnos)
            {
                sb.Append(string.Format(alumno.ToString()));
            }
            sb.AppendLine("<------------------------------------------------------------->");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Una Jornada sera igual a un Alumno si el mismo participa en la clase
        /// </summary>
        /// <param name="j">Jornada a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Resultado de la comparacion</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Universitario alumno in j.alumnos)
            {
                if (alumno.Equals(a))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Jornada sera distinto a un Alumno si el mismo participa en la clase
        /// </summary>
        /// <param name="j">Jornada a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega Alumnos a la clase validando que no esten previamente cargados.
        /// </summary>
        /// <param name="j">Jornada a verificar</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Retorna el alumno cargado en la Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
