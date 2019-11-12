using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//agregando

namespace CienMexicanos
{
    class Vista
    {
        public void limpiaTablero(Label lb1, Label lb2, Label lb3, Label lb4, Label lb5)
        {
            lb1.Text = "...";
            lb2.Text = "...";
            lb3.Text = "...";
            lb4.Text = "...";
            lb5.Text = "...";        
        }

        public void deshabilitarRespuesta(Button boton1)
        {
            boton1.Enabled = false;          
        }

        public void habilitarRespuestas(Button boton1, Button boton2, Button boton3, Button boton4, Button boton5)
        {
            boton1.Enabled = true;
            boton2.Enabled = true;
            boton3.Enabled = true;
            boton4.Enabled = true;
            boton5.Enabled = true;
        }

        public void mensajeSeleccionado(string pregunta)
        {
            MessageBox.Show(pregunta, "Pregunta seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        public void verPregunta(Label ver, ComboBox pregunta)
        {
            ver.Text=pregunta.SelectedItem.ToString();
        }
    }//class
}//namespace