using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CienMexicanos
{
    class Puntos
    {
        static private int equipoA;
        static private int equipoB;
        static private int total;
        static private int valor1;
        static private int valor2;
        static private int valor3;
        static private int valor4;
        static private int valor5;

        public void valorRespuestas(int r1, int r2, int r3, int r4, int r5)
        {
            valor1 = r1;
            valor2 = r2;
            valor3 = r3;
            valor4 = r4;
            valor5 = r5;
        }  

        public int totalPuntos()
        {
            return total;
        }

        public void resetTotal()
        {
            total = 0;
        }

        public int valorRespuesta1()
        {
            return valor1;
        }

        public int valorRespuesta2()
        {
            return valor2;
        }

        public int valorRespuesta3()
        {
            return valor3;
        }

        public int valorRespuesta4()
        {
            return valor4;
        }

        public int valorRespuesta5()
        {
            return valor5;
        }

        public void sumaA()
        {
            equipoA += total;
        }

        public void sumaB()
        {
            equipoB += total;
        }

        public void acumulaPuntos(int valor)
        {
            total+=valor;
        } 

        public int devuelePuntosA()
        {
            return equipoA;
        }

        public int devuelePuntosB()
        {
            return equipoB;
        }        
    }//class
}//namespace