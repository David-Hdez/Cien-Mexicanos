using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//agregando
using System.Windows.Forms;

namespace CienMexicanos
{
    class JuegoRapido
    {
        private int puntajeFinal;
        public ArrayList RespuestasFG = new ArrayList();
        private ronda sesion;

        public void sesionRespuestas(int IDquestion, string question, string respuesta, int puntos)
        {
            sesion = new ronda(IDquestion, question, respuesta, puntos);
            RespuestasFG.Add(sesion);
        }

        public void jugadorB_arreglo(ListBox pantalla)
        {
            string pregunta = "";
            int idpregunta = 0;            
            pantalla.Items.Clear();
            for (int i = 0; i <= 4; i++)
            {
                idpregunta=((ronda)RespuestasFG[i]).idPregunta ;
                pregunta = ((ronda)RespuestasFG[i]).enunciado;

                sesion = new ronda(idpregunta, pregunta, "...", 0);
                RespuestasFG.Add(sesion);
            }

            for (int i = 5; i <= 9; i++)
            {
                pantalla.Items.Add("(" + ((ronda)RespuestasFG[i]).idPregunta + ")" + ((ronda)RespuestasFG[i]).enunciado + " - " + ((ronda)RespuestasFG[i]).respuesta + " - " + ((ronda)RespuestasFG[i]).valor);
            }
        }

        public void respuestasJugador(int IDquestion, string respuesta, int puntos)
        {
            ((ronda)RespuestasFG[IDquestion]).respuesta = respuesta;
            ((ronda)RespuestasFG[IDquestion]).valor = puntos;
        }

        public void visualizarPreguntasRapidasLB(ListBox pantalla)
        {
            foreach (ronda item in RespuestasFG)
            {
                pantalla.Items.Add("(" + item.idPregunta + ")" + item.enunciado + " - " + item.respuesta + " - " + item.valor);
            }
        }

        public void visualizarPreguntasRapidasLBJUGADORB(ListBox pantalla)
        {
            for (int i = 5; i <= 9; i++)
            {
                pantalla.Items.Add(((ronda)RespuestasFG[i]).enunciado + " - " + ((ronda)RespuestasFG[i]).respuesta + " - " + ((ronda)RespuestasFG[i]).valor);
            }
        }

        public int seleccionPreguntaLBparaMostrar(int indice)
        {
            return ((ronda)RespuestasFG[indice]).idPregunta;
        }

        public void verPreguntaLista(int indice, GroupBox caja)
        {
            caja.Text= ((ronda)RespuestasFG[indice]).enunciado;
        }

        public void verEnLBJugadorA(ListBox pantalla)
        {
            foreach (ronda item in RespuestasFG)
            {
                pantalla.Items.Add(item.enunciado + " - " +  item.respuesta + " - " + item.valor);
            }
        }

        public void verEnLBJugadorAREPETIDAS(ListBox pantalla)
        {           
            for (int i = 0; i <= 4; i++)
            {
                pantalla.Items.Add(i + " - " + ((ronda)RespuestasFG[i]).respuesta);
            }
        }

        public void verEnLBJugadorB(ListBox pantalla)
        {
            for (int i = 5; i <= 9; i++)
            {
                pantalla.Items.Add(((ronda)RespuestasFG[i]).enunciado + " - " + ((ronda)RespuestasFG[i]).respuesta + " - " +((ronda)RespuestasFG[i]).valor);
            }
        }

        public string devuelvePregunta(int id)
        {
            //Console.WriteLine(((Test)miArray[0]).Atributo);
            string question = ((ronda)RespuestasFG[id]).respuesta;
            return question;
        }

        public int devuelveValor(int id)
        {           
            int suma = ((ronda)RespuestasFG[id]).valor;
            puntajeFinal += suma;
            return suma;
        }

        public int verPuntuajeFinal()
        {
            return puntajeFinal;
        }
    }//class
}//namespace