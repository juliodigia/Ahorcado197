using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AhorcadoClass
{
    public class AhorcadoClass
    {
        public AhorcadoClass()
        {
            palabra = "caracoles";
            AsignarPalabra(palabra);

        }

        public AhorcadoClass(int Modo)
        {
            LetrasErradas = "      ";
            ContErrores = 0;

        }

        public AhorcadoClass(string palabra)
        {
            AsignarPalabra(palabra);
            LetrasErradas = "      ";
            ContErrores = 0;
        }

        private DateTime inicio;
        public DateTime Inicio
        {
            get { return this.inicio; }
            set { this.inicio = value; }
        }

        private DateTime fin;
        public DateTime Fin
        {
            get { return this.fin; }
            set { this.fin = value; }
        }

        static int indiceLetraErrada = 1;
        private string letrasErradas;
        public string LetrasErradas
        {
            get { return this.letrasErradas; }
            set { this.letrasErradas = value; }
        }

        private int contErrores;
        public int ContErrores
        {
            get
            {
                return this.contErrores;
            }
            set
            {
                this.contErrores = value;
            }
        }

        private string nombre;
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        private string palabraAdivinada;
        public string PalabraAdivinada
        {
            get { return this.palabraAdivinada; }
            set { this.palabraAdivinada = value; }
        }
        private string palabra;
        public string Palabra
        {
            get { return this.palabra; }
            set { this.palabra = value; }
        }
        public void AsignarNombre(string x)
        {

            this.Nombre = x;
        }

        public string AsignarPalabraRandom()
        {
            string[] todasLasPalabras = new string[10] { "mierda", "extravagante", "epsilon", "grandioso", "sol", "calefactor", "puerta", "golpe", "sillon", "esdrujula" };
            Random rm = new Random();
            int nro = rm.Next(1, 10);
            Palabra = todasLasPalabras[nro];
            return Palabra;

        }

        public void AsignarPalabra(string x)
        {

            this.Palabra = x;
            for (int i = 0; i <= Palabra.Length - 1; i++)
            {
                if (Palabra.Substring(i, 1) != " ")
                {
                    PalabraAdivinada = PalabraAdivinada + "-";

                }
                else
                {
                    PalabraAdivinada = PalabraAdivinada + " ";
                }
            }
        }

        public int CantLetras()
        {
            return palabra.Length;
        }

        public string IngresarLetra(string letra)
        {

            if (Palabra.Contains(letra))
            {

                for (int i = 0; i <= Palabra.Length - 1; i++)
                {
                    string letraAux = Palabra.Substring(i, 1);
                    if (letra == letraAux)
                    {
                        PalabraAdivinada = PalabraAdivinada.Remove(i, 1);
                        PalabraAdivinada = PalabraAdivinada.Insert(i, letra);
                    }
                }

                if (PalabraAdivinada.Contains("-"))
                {
                    return PalabraAdivinada;
                }
                else
                {
                    return "Palabra adivinada";
                }
            }
            else
            {

                LetrasErradas = LetrasErradas.Insert(indiceLetraErrada, letra);
                indiceLetraErrada++;
                ContErrores++;
                if (ContErrores == 6) { return "Perdiste, queso"; }
                return "letra incorrecta";
            }


        }



        public bool ValidarPalabra()
        {
            foreach (var letra in Palabra.ToCharArray())
            {
                if (!PalabraAdivinada.Contains(Char.ToLower(letra)))
                {
                    return false;
                }
            }
            return true;
        }


        public double CalcularTiempoJuego(DateTime ini, DateTime fin)
        {
            var segundos = (fin - ini).TotalSeconds;
            return segundos;
        }

        public string ArriesgarPalabra(string x)
        {
            string palabraArriesgada = x;
            if (Palabra == palabraArriesgada)
            {
                return "arriesgaste bien, campeon";
            }
            else return "te apuraste y te la mandaste, perdedor";
        }




    }
}
