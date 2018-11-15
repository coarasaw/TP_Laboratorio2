using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace UnitTestTP3
{
    [TestClass]
    public class UnitTestTP1
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethodTP3_1()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "2123", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestMethodTP3_2()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "2123", EntidadesAbstractas.Persona.ENacionalidad.Argentino , Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            Xml<Alumno> arch = new Xml<Alumno>();
            arch.Guardar("RutaInvalida:\\pepe.xml", a2);
        }
        
        [TestMethod]
        public void TestMethodTP3_4()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Instructores);
        }
    }
}
