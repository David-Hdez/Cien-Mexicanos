using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CienMexicanos
{
    public partial class FormPanel : Form
    {
        FormTablero tablero = new FormTablero();
        Controlador objControl = new Controlador();
        Vista objVista = new Vista();
        Puntos objPuntos = new Puntos();
        JuegoRapido objFastGame = new JuegoRapido();
        int itemSeleccionadoCB;
        int itemSeleccionadoLB=0;
        bool turnoA = true;
        int contadorFG = 0;
        int segundos = 5;
        private int faltaEquipoA;
        private int faltaEquipoB;

        public FormPanel()
        {
            InitializeComponent();

            tablero.Show();
        }  

        private void FormPanel_Load(object sender, EventArgs e)
        {
            objControl.AbrirConexion();            
            objControl.verPreguntasenCombo(objControl.cargarPreguntas(), comboBoxPreguntas);//CARGANDO PREGUNTAS DE LA BASE
            objControl.verPreguntasenCombo(objControl.cargarPreguntas(), cbPreguntasFastGame);//CARGANDO PREGUNTAS DE LA BASE
            objControl.cerrarBase();
        }

        private void btnMostrar1_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta1.Text = lbRespuesta1.Text;//mostrar respuesta
            objControl.SumaPuntos(lbPuntuaje, objPuntos.valorRespuesta1());
            tablero.lbTotal.Text = lbPuntuaje.Text;
            objVista.deshabilitarRespuesta(btnMostrar1);
            objControl.PlayAudioCorrecto();
        }

        private void btnMostrar2_Click(object sender, EventArgs e)
        {            
            tablero.lbRespuesta2.Text = lbRespuesta2.Text;//mostrar respuesta
            objControl.SumaPuntos(lbPuntuaje, objPuntos.valorRespuesta2());
            tablero.lbTotal.Text = lbPuntuaje.Text;
            objVista.deshabilitarRespuesta(btnMostrar2);
            objControl.PlayAudioCorrecto();
        }

        private void btnMostrar3_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta3.Text = lbRespuesta3.Text;//mostrar respuesta
            objControl.SumaPuntos(lbPuntuaje, objPuntos.valorRespuesta3());
            tablero.lbTotal.Text = lbPuntuaje.Text;
            objVista.deshabilitarRespuesta(btnMostrar3);
            objControl.PlayAudioCorrecto();
        }

        private void btnMostrar4_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta4.Text = lbRespuesta4.Text;//mostrar respuesta
            objControl.SumaPuntos(lbPuntuaje, objPuntos.valorRespuesta4());
            tablero.lbTotal.Text = lbPuntuaje.Text;
            objVista.deshabilitarRespuesta(btnMostrar4);
            objControl.PlayAudioCorrecto();
        }

        private void btnMostrar5_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta5.Text = lbRespuesta5.Text;//mostrar respuesta
            objControl.SumaPuntos(lbPuntuaje, objPuntos.valorRespuesta5());
            tablero.lbTotal.Text = lbPuntuaje.Text;
            objVista.deshabilitarRespuesta(btnMostrar5);
            objControl.PlayAudioCorrecto();
        }

        private void btnSumarA_Click(object sender, EventArgs e)
        {
            objControl.PlayAudioCorrecto();
            objPuntos.sumaA();           
            tablero.lbPuntuajeEquipo1.Text = objPuntos.devuelePuntosA().ToString();
            tablero.lbTotal.Text = 0.ToString();
            objVista.limpiaTablero(tablero.lbRespuesta1, tablero.lbRespuesta2, tablero.lbRespuesta3, tablero.lbRespuesta4, tablero.lbRespuesta5);
        }

        private void comboBoxPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablero.lbTotal.Text = "00";
            tablero.pbErrorA1.Visible = false;
            tablero.pbErrorA2.Visible = false;
            tablero.pbErrorA3.Visible = false;
            tablero.pbErrorB1.Visible = false;
            tablero.pbErrorB2.Visible = false;
            tablero.pbErrorB3.Visible = false;
            faltaEquipoA = 0;
            faltaEquipoB = 0;

            itemSeleccionadoCB = comboBoxPreguntas.SelectedIndex;
            //cargando de base pregunta seleccionada
            objControl.AbrirConexion();
            objVista.mensajeSeleccionado(comboBoxPreguntas.SelectedItem.ToString());
            objControl.mostrarRespuestas(objControl.cargarRespuestasValor(Convert.ToInt32((comboBoxPreguntas.SelectedItem as ComboboxItem).Value)), lbRespuesta1, lbRespuesta2, lbRespuesta3, lbRespuesta4, lbRespuesta5);//int id = Convert.ToInt32((comboBoxPreguntas.SelectedItem as ComboboxItem).Value); 
            objControl.cerrarBase();
            //cargando base pregunta seleccionada
            objVista.verPregunta(lbPregunta, comboBoxPreguntas);
            comboBoxPreguntas.Items.RemoveAt(itemSeleccionadoCB);//removiendo la pregunta seleccionada
            cbPreguntasFastGame.Items.RemoveAt(itemSeleccionadoCB);//removiendo la pregunta seleccionada
            objVista.limpiaTablero(tablero.lbRespuesta1, tablero.lbRespuesta2, tablero.lbRespuesta3, tablero.lbRespuesta4, tablero.lbRespuesta5);
            objVista.habilitarRespuestas(btnMostrar1, btnMostrar2, btnMostrar3, btnMostrar4, btnMostrar5);//habilitando botones depues de mostrar respuesta
            objPuntos.resetTotal();//contador a 0 para acumular puntos de pregunta
        }

        private void btnSumarB_Click(object sender, EventArgs e)
        {
            objControl.PlayAudioCorrecto();
            objPuntos.sumaB();           
            tablero.lbPuntuajeEquipo2.Text = objPuntos.devuelePuntosB().ToString();
            tablero.lbTotal.Text = 0.ToString();
            objVista.limpiaTablero(tablero.lbRespuesta1, tablero.lbRespuesta2, tablero.lbRespuesta3, tablero.lbRespuesta4, tablero.lbRespuesta5);
        }

        private void cbPreguntasFastGame_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            /*if (contadorFG <4)
            {
                contadorFG++;*/
                itemSeleccionadoCB = cbPreguntasFastGame.SelectedIndex;
                listBoxJuegoRapido.Items.Clear();
                //cargando de base pregunta seleccionada
                objControl.AbrirConexion();
                objVista.mensajeSeleccionado(cbPreguntasFastGame.SelectedItem.ToString());
                string pregunta = cbPreguntasFastGame.SelectedItem.ToString();
                objFastGame.sesionRespuestas(Convert.ToInt32((cbPreguntasFastGame.SelectedItem as ComboboxItem).Value), pregunta, "...", 0);
                objFastGame.visualizarPreguntasRapidasLB(listBoxJuegoRapido);
                objControl.cerrarBase();//cargando base pregunta seleccionada         
                comboBoxPreguntas.Items.RemoveAt(itemSeleccionadoCB);//removiendo la pregunta seleccionada
                cbPreguntasFastGame.Items.RemoveAt(itemSeleccionadoCB);//removiendo la pregunta seleccionada                    
            /*}
            else
            {
                MessageBox.Show("Seleccionadas las 5 preguntas", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cbPreguntasFastGame.Enabled = false;
                listBoxJuegoRapido.SetSelected(0, true);
            } */   
        }

        private void btnRespuesta1_Click(object sender, EventArgs e)
        {       
            foreach (Control ctrl in groupBoxPregunta1.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton radio = ctrl as RadioButton;
                    if (radio.Checked)
                    {                  
                        switch (radio.Name)
                        {
                            case "rbRespuesta11":
                                if (turnoA){
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, rbRespuesta11.Text, Convert.ToInt32(lbVP11.Text));
                                } else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex+5, rbRespuesta11.Text, Convert.ToInt32(lbVP11.Text)); }
                                break;

                            case "rbRespuesta12":
                                if (turnoA)
                                {
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, rbRespuesta12.Text, Convert.ToInt32(lbVP12.Text));
                                }
                                else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex + 5, rbRespuesta12.Text, Convert.ToInt32(lbVP12.Text)); }
                                break;

                            case "rbRespuesta13":
                                if (turnoA)
                                {
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, rbRespuesta13.Text, Convert.ToInt32(lbVP13.Text));
                                }
                                else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex + 5, rbRespuesta13.Text, Convert.ToInt32(lbVP13.Text)); }
                                break;

                            case "rbRespuesta14":
                                if (turnoA)
                                {
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, rbRespuesta14.Text, Convert.ToInt32(lbVP14.Text));
                                }
                                else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex + 5, rbRespuesta14.Text, Convert.ToInt32(lbVP14.Text)); }
                                break;

                            case "rbRespuesta15":
                                if (turnoA)
                                {
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, rbRespuesta15.Text, Convert.ToInt32(lbVP15.Text));
                                }
                                else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex + 5, rbRespuesta15.Text, Convert.ToInt32(lbVP15.Text)); }
                                break;

                            case "rbCustom16":
                                //objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, txtRespuestaCustom1.Text, 0);
                                if (turnoA)
                                {
                                    objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex, txtRespuestaCustom1.Text, 0);
                                }
                                else { objFastGame.respuestasJugador(listBoxJuegoRapido.SelectedIndex + 5, txtRespuestaCustom1.Text, 0); }
                                break;
                        }//switch

                        break;
                    }//if radio ckecked
                }
            }//foreach

            listBoxJuegoRapido.Items.Clear();
            if (turnoA)
            {
                objFastGame.visualizarPreguntasRapidasLB(listBoxJuegoRapido);
            }
            else
            { objFastGame.visualizarPreguntasRapidasLBJUGADORB(listBoxJuegoRapido); }
        }//btn               

        private void button3_Click(object sender, EventArgs e)
        {
            objFastGame.verEnLBJugadorAREPETIDAS(lbRespuestasJugadorA);
            try
            {                
                objFastGame.verEnLBJugadorA(listBoxRespuestasJugador1);                                
                objFastGame.verEnLBJugadorB(listBoxRespuestasJugador2);
            }
            catch (Exception)
            {
                MessageBox.Show("Turno jugador B", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                objFastGame.jugadorB_arreglo(listBoxJuegoRapido);
                turnoA = false;               
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int seleccionado = listBoxRespuestasJugador1.SelectedIndex;            
            btnMostrarValorFastGame1.Enabled = true;
            btnRespuestasFastGame1.Enabled = false;
            listBoxRespuestasJugador1.Enabled = false;     

            switch (seleccionado)
            {
                case 0:                  
                    tablero.lbRespuesta1.Text = objFastGame.devuelvePregunta(listBoxRespuestasJugador1.SelectedIndex);
                    break;
                case 1:
                    tablero.lbRespuesta2.Text = objFastGame.devuelvePregunta(listBoxRespuestasJugador1.SelectedIndex);
                    break;
                case 2:
                    tablero.lbRespuesta3.Text = objFastGame.devuelvePregunta(listBoxRespuestasJugador1.SelectedIndex);
                    break;
                case 3:
                    tablero.lbRespuesta4.Text = objFastGame.devuelvePregunta(listBoxRespuestasJugador1.SelectedIndex);
                    break;
                case 4:
                    tablero.lbRespuesta5.Text = objFastGame.devuelvePregunta(listBoxRespuestasJugador1.SelectedIndex);
                    break;                
            }
        }

        private void btnMostrarValorFastGame_Click(object sender, EventArgs e)
        {
            int seleccionado = listBoxRespuestasJugador1.SelectedIndex;            
            btnMostrarValorFastGame1.Enabled = false;
            btnRespuestasFastGame1.Enabled = true;
            listBoxRespuestasJugador1.Enabled = true;

            switch (seleccionado)
            {
                case 0:                    
                    tablero.lbValorJuegoRapido1.Visible = true;
                    tablero.lbValorJuegoRapido1.Text = objFastGame.devuelveValor(listBoxRespuestasJugador1.SelectedIndex).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;             
                case 1:
                    tablero.lbValorJuegoRapido2.Visible = true;
                    tablero.lbValorJuegoRapido2.Text = objFastGame.devuelveValor(listBoxRespuestasJugador1.SelectedIndex).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 2:
                    tablero.lbValorJuegoRapido3.Visible = true;
                    tablero.lbValorJuegoRapido3.Text = objFastGame.devuelveValor(listBoxRespuestasJugador1.SelectedIndex).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 3:
                    tablero.lbValorJuegoRapido4.Visible = true;
                    tablero.lbValorJuegoRapido4.Text = objFastGame.devuelveValor(listBoxRespuestasJugador1.SelectedIndex).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 4:
                    tablero.lbValorJuegoRapido5.Visible = true;
                    tablero.lbValorJuegoRapido5.Text = objFastGame.devuelveValor(listBoxRespuestasJugador1.SelectedIndex).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
            }
        }

        private void btnLimpiarTablero_Click(object sender, EventArgs e)
        {           
            //RESPUESTAS PANTALLA:
            tablero.lbRespuesta1.Visible = false;
            tablero.lbRespuesta2.Visible = false;
            tablero.lbRespuesta3.Visible = false;
            tablero.lbRespuesta4.Visible = false;
            tablero.lbRespuesta5.Visible = false;
            tablero.lbValorJuegoRapido1.Visible = false;
            tablero.lbValorJuegoRapido2.Visible = false;
            tablero.lbValorJuegoRapido3.Visible = false;
            tablero.lbValorJuegoRapido4.Visible = false;
            tablero.lbValorJuegoRapido5.Visible = false;
            tablero.lbTotal.Visible = false;
        }//btn

        private void btnRespuestasFastGame2_Click(object sender, EventArgs e)
        {
            int seleccionado = listBoxRespuestasJugador2.SelectedIndex+5;
            btnMostrarValorFastGame2.Enabled = true;
            btnRespuestasFastGame2.Enabled = false;
            listBoxRespuestasJugador2.Enabled = false;

            switch (seleccionado)
            {
                case 5:
                    tablero.lbRespuestaRapida21.Visible = true;
                    tablero.lbRespuestaRapida21.Text = objFastGame.devuelvePregunta(5);
                    break;
                case 6:
                    tablero.lbRespuestaRapida22.Visible = true;
                    tablero.lbRespuestaRapida22.Text = objFastGame.devuelvePregunta(6);
                    break;
                case 7:
                    tablero.lbRespuestaRapida23.Visible = true;
                    tablero.lbRespuestaRapida23.Text = objFastGame.devuelvePregunta(7);
                    break;
                case 8:
                    tablero.lbRespuestaRapida24.Visible = true;
                    tablero.lbRespuestaRapida24.Text = objFastGame.devuelvePregunta(8);
                    break;
                case 9:
                    tablero.lbRespuestaRapida25.Visible = true;
                    tablero.lbRespuestaRapida25.Text = objFastGame.devuelvePregunta(9);
                    break;
            }
        }

        private void btnMostrarValorFastGame2_Click(object sender, EventArgs e)
        {
            int seleccionado = listBoxRespuestasJugador2.SelectedIndex+5;
            btnMostrarValorFastGame2.Enabled = false;
            btnRespuestasFastGame2.Enabled = true;
            listBoxRespuestasJugador2.Enabled = true;

            switch (seleccionado)
            {
                case 5:
                    tablero.lbValorJuegoRapido21.Visible = true;
                    tablero.lbValorJuegoRapido21.Text = objFastGame.devuelveValor(5).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 6:
                    tablero.lbValorJuegoRapido22.Visible = true;
                    tablero.lbValorJuegoRapido22.Text = objFastGame.devuelveValor(6).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 7:
                    tablero.lbValorJuegoRapido23.Visible = true;
                    tablero.lbValorJuegoRapido23.Text = objFastGame.devuelveValor(7).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 8:
                    tablero.lbValorJuegoRapido24.Visible = true;
                    tablero.lbValorJuegoRapido24.Text = objFastGame.devuelveValor(8).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
                case 9:
                    tablero.lbValorJuegoRapido25.Visible = true;
                    tablero.lbValorJuegoRapido25.Text = objFastGame.devuelveValor(9).ToString();
                    tablero.lbTotal.Text = objFastGame.verPuntuajeFinal().ToString();
                    break;
            }
        }

        private void btnPantallaPlayerA_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta1.Visible = true;
            tablero.lbRespuesta2.Visible = true;
            tablero.lbRespuesta3.Visible = true;
            tablero.lbRespuesta4.Visible = true;
            tablero.lbRespuesta5.Visible = true;
            tablero.lbValorJuegoRapido1.Visible = true;
            tablero.lbValorJuegoRapido2.Visible = true;
            tablero.lbValorJuegoRapido3.Visible = true;
            tablero.lbValorJuegoRapido4.Visible = true;
            tablero.lbValorJuegoRapido5.Visible = true;
            tablero.lbTotal.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            faltaEquipoA++;
            switch (faltaEquipoA)
            {
                case 1:
                    tablero.pbErrorA1.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    break;
                case 2:
                    tablero.pbErrorA2.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    break;
                case 3:
                    tablero.pbErrorA3.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    faltaEquipoA = 0;
                    break;          
            }
        }

        private void btnFaltaB_Click(object sender, EventArgs e)
        {
            faltaEquipoB++;
            switch (faltaEquipoB)
            {
                case 1:
                    tablero.pbErrorB1.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    break;
                case 2:
                    tablero.pbErrorB2.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    break;
                case 3:
                    tablero.pbErrorB3.Visible = true;
                    objControl.PlayAudioIncorrecto();
                    faltaEquipoB = 0;
                    break;
            }
        }

        private void listBoxJuegoRapido_SelectedIndexChanged(object sender, EventArgs e)
        {            
            objControl.mostrarRespuestaRapidas(objControl.cargarRespuestasValor(objFastGame.seleccionPreguntaLBparaMostrar(listBoxJuegoRapido.SelectedIndex)), rbRespuesta11, rbRespuesta12, rbRespuesta13, rbRespuesta14, rbRespuesta15, lbVP11, lbVP12, lbVP13, lbVP14, lbVP15);
            objFastGame.verPreguntaLista(listBoxJuegoRapido.SelectedIndex, groupBoxPregunta1);
        }

        private void btnFGSiguiente_Click(object sender, EventArgs e)
        {
            try
            {             
                listBoxJuegoRapido.SetSelected(itemSeleccionadoLB+1, true);
                itemSeleccionadoLB++;
            }
            catch (Exception)
            {
                MessageBox.Show("5 preguntas", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //listBoxJuegoRapido.SelectedIndex = 0;
                itemSeleccionadoLB = 0;
                listBoxJuegoRapido.SetSelected(0, true);
            }
        }

        private void btnRespuestaNoEsta_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            objControl.PlayAudioIncorrecto();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos--;
            tablero.pictureBoxNoEsta.Visible = true;
            //lbPregunta.Text = segundos.ToString();

            if (segundos == 0)
            {
                timer1.Stop();
                tablero.pictureBoxNoEsta.Visible = false;
            }
        }

        private void btnMuestraTodo_Click(object sender, EventArgs e)
        {
            tablero.lbRespuesta1.Text = lbRespuesta1.Text;//mostrar respuesta
            tablero.lbRespuesta2.Text = lbRespuesta2.Text;//mostrar respuesta
            tablero.lbRespuesta3.Text = lbRespuesta3.Text;//mostrar respuesta
            tablero.lbRespuesta4.Text = lbRespuesta4.Text;//mostrar respuesta
            tablero.lbRespuesta5.Text = lbRespuesta5.Text;//mostrar respuesta
        }
    }//class
}//namespace