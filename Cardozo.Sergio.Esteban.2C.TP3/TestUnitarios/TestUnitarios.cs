using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(1, "Sergio", "Cardozo", "900000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

        }
        
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Alumno alumno = new Alumno(1, "Roman", "Riquelme", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno1 = new Alumno(1, "Sergio", "Cardozo", "35804304", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad universidad = new Universidad();
            universidad += alumno;
            universidad += alumno1;

            Assert.AreEqual(alumno, alumno1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoException()
        {
            Alumno alumno = new Alumno(1, "Sergio", "Cardozo", "Esteban", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            
        }
        
        [TestMethod]
        public void SinProfesorException()
        {
            try
            {
                Universidad universidad = new Universidad();
                Profesor profesor = universidad == Universidad.EClases.Laboratorio;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
      
        [TestMethod]
        public void TestCantidadDeAlumnos()
        {
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(9, "Martin", "Palermo", "23569410", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(10, "Roman", "Riquelme", "26752869", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            universidad += alumno1;
            universidad += alumno2;

            Assert.AreEqual(2, universidad.Alumnos.Count);
        }
       
        [TestMethod]
        public void TestValidaAtributoNull()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
        }
        
        [TestMethod]
        public void TestAtributoNumerico()
        {
            int valor = 35804304;
            Alumno alumno = new Alumno(1, "Sergio", "Cardozo", "35804304", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.AreEqual(valor, alumno.DNI);
        }

        [TestMethod]
        public void ValidarJornadaNoEsNull()
        {
            Profesor profesor = new Profesor(666, "Fede", "Davila", "12345678", Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Programacion, profesor);

            Assert.IsNotNull(jornada.Alumnos);
        }
    }
}
