using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CienMexicanos
{
    class ronda
    {
        public int idPregunta { get; set; }
        public string enunciado { get; set; }
        public string respuesta { get; set; }
        public int valor { get; set; }   

        public ronda(int id, string question, string answer, int puntos)
        {
            idPregunta = id;
            enunciado = question;
            respuesta = answer;
            valor = puntos;
        }
    }//class
}//namespace