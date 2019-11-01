using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AhorcadoClass;


namespace Ahorcado
{
    [TestClass]
    public class AhorcadoTest
    {
        [TestMethod]
        public void TestIngresarNombre()
        {
            AhorcadoClass.AhorcadoClass ahorcadoGame = new AhorcadoClass.AhorcadoClass();
            string nombre = "Manuel";
            ahorcadoGame.AsignarNombre(nombre);
            Assert.AreEqual(nombre, ahorcadoGame.Nombre);

        }

        [TestMethod]
        public void TestUnaPalabra()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            string palabra = "caracoles";
            ahoracadoGame.AsignarPalabra(palabra);
            Assert.AreEqual(palabra, ahoracadoGame.Palabra);
        }

        [TestMethod]
        public void IngresCaracoles_EsperoLongitud9()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            string palabra = "caracoles";
            ahoracadoGame.AsignarPalabra(palabra);

            Assert.AreEqual(9, ahoracadoGame.CantLetras());
        }

        [TestMethod]
        public void IngresoLetraIncorrecta_devuelveLetraIncorrecta()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass(2);
            string palabra = "caracoles";
            string letra = "k";
            ahoracadoGame.AsignarPalabra(palabra);
            Assert.AreEqual("letra incorrecta", ahoracadoGame.IngresarLetra(letra));
        }


        [TestMethod]
        public void IngresoLetraO_CorrectoPosicion6()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            string letra = "o";
            Assert.AreEqual("-----o---", ahoracadoGame.IngresarLetra(letra));
        }

        [TestMethod]
        public void PalabraAdivinada_todosGuiones()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            Assert.AreEqual("---------", ahoracadoGame.PalabraAdivinada);
        }

        [TestMethod]
        public void IngresoLetraA_CorrectoPosicion6()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            string letra = "a";
            Assert.AreEqual("-a-a-----", ahoracadoGame.IngresarLetra(letra));
        }
        [TestMethod]
        public void IngresarLetraErronea_ContarErrores()
        {

            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass(2);
            ahoracadoGame.AsignarPalabra("cara");
            ahoracadoGame.IngresarLetra("k");
            ahoracadoGame.IngresarLetra("t");
            ahoracadoGame.IngresarLetra("p");
            Assert.AreEqual(3, ahoracadoGame.ContErrores);
        }

        [TestMethod]
        public void IngresarLaSegundaLetra_estaBien()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            ahoracadoGame.IngresarLetra("a");
            ahoracadoGame.IngresarLetra("l");

            Assert.AreEqual("-a-a--l--", ahoracadoGame.IngresarLetra("l"));
        }


        [TestMethod]
        public void IngresarUltimaLetra_ganasteWinner()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            ahoracadoGame.IngresarLetra("c");
            ahoracadoGame.IngresarLetra("a");
            ahoracadoGame.IngresarLetra("r");
            ahoracadoGame.IngresarLetra("o");
            ahoracadoGame.IngresarLetra("l");
            ahoracadoGame.IngresarLetra("s");
            Assert.AreEqual("Palabra adivinada", ahoracadoGame.IngresarLetra("e"));
        }

        [TestMethod]
        public void Hiciste6errores_Perdiste()
        {
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass(2);
            ahoracadoGame.AsignarPalabra("cara");
            ahoracadoGame.IngresarLetra("f");
            ahoracadoGame.IngresarLetra("p");
            ahoracadoGame.IngresarLetra("y");
            ahoracadoGame.IngresarLetra("u");
            ahoracadoGame.IngresarLetra("q");
            Assert.AreEqual("Perdiste, queso", ahoracadoGame.IngresarLetra("b"));
        }

        [TestMethod]
        public void CalcularElTiempo_verdadero()
        {
            DateTime inicioJuego = new DateTime(2019, 6, 3, 18, 00, 00); // 18.00
            DateTime finJuego = new DateTime(2019, 6, 3, 18, 10, 10); // 18.10
            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            Assert.AreEqual(610, ahoracadoGame.CalcularTiempoJuego(inicioJuego, finJuego));

        }

        [TestMethod]
        public void ArriesgarPalabraMierda_verdadero()
        {

            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            ahoracadoGame.AsignarPalabra("mierda");
            Assert.AreEqual("arriesgaste bien, campeon", ahoracadoGame.ArriesgarPalabra("mierda"));

        }

        [TestMethod]
        public void ArriesgarPalabraPerdedora_PerdisteRey()
        {

            AhorcadoClass.AhorcadoClass ahoracadoGame = new AhorcadoClass.AhorcadoClass();
            ahoracadoGame.AsignarPalabraRandom();
            Assert.AreEqual("te apuraste y te la mandaste, perdedor", ahoracadoGame.ArriesgarPalabra("cacona"));

        }


    }


}

