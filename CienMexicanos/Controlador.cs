using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//agregando
using System.Data;
using System.Windows.Forms;
using System.Collections;//arrayList
using System.Media;

namespace CienMexicanos
{   
    class Controlador
    {  
        private string cadCon = "Data Source = JARVIS; initial Catalog = cienmxn; Integrated Security = true";
        private string mensaje;
        SqlCommand comando = new SqlCommand();
        SqlConnection cn1 = new SqlConnection();
        Puntos puntuacion;        

        public Controlador()
        {
            puntuacion = new Puntos();
        }

        public string verMensaje()
        {
            return mensaje;
        }

        public void cerrarBase()
        {
            cn1.Close();
        }

        public SqlConnection AbrirConexion()//ref string mensaje
        {
            //SqlConnection cn1 = new SqlConnection();
            if (cadCon != null)
            {
                cn1.ConnectionString = cadCon;
                try
                {
                    cn1.Open();
                    mensaje = "Conexión exitosa";
                }//try
                catch (Exception u)
                {
                    mensaje = u.Message;
                    cn1 = null;
                }//catch
            }//if
            else
            {
                cn1 = null;
                mensaje = "Error de conexión";
            }//else
            return cn1;
        }//abrir conexion        

        public void verPreguntasenCombo(DataSet ds, ComboBox combo)
        {
            DataTable dt = ds.Tables[0];
            combo.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = Convert.ToString(row["enunciado"]);
                item.Value = Convert.ToInt32(row["idPregunta"]);
                combo.Items.Add(item);
            }
        }

        //CARGAR RESPUESTAS RONDA NORMAL
        public DataSet cargarRespuestasValor(int preguntaID)
        {
            DataSet respuesta = new DataSet();
            comando.Parameters.Clear();
            comando.Connection = cn1;
            SqlParameter Par_Nacion = comando.Parameters.Add("pregunta", SqlDbType.Int);
            Par_Nacion.Value = preguntaID;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "muestraRepuestasyValor";
            SqlDataAdapter lector = new SqlDataAdapter(comando);
            lector.Fill(respuesta);              

            return respuesta;
        }//autor en especifico

        public void mostrarRespuestas(DataSet ds, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5)
        {
            DataTable dt = ds.Tables[0];
            /*foreach (DataRow row in dt.Rows)
            {
                lb1.Text = Convert.ToString(row["Respuestas"]);
                lb2.Text = Convert.ToString(row["Puntos"]);
            }*/
            /*lb1.Text = dt.Rows[0]["Respuestas"].ToString();
            lb2.Text = dt.Rows[0]["Puntos"].ToString();*/
            lb1.Text = dt.Rows[0]["Respuestas"].ToString() + " - " + dt.Rows[0]["Puntos"].ToString();
            lb2.Text = dt.Rows[1]["Respuestas"].ToString() + " - " + dt.Rows[1]["Puntos"].ToString();
            lb3.Text = dt.Rows[2]["Respuestas"].ToString() + " - " + dt.Rows[2]["Puntos"].ToString();
            lb4.Text = dt.Rows[3]["Respuestas"].ToString() + " - " + dt.Rows[3]["Puntos"].ToString();
            lb5.Text = dt.Rows[4]["Respuestas"].ToString() + " - " + dt.Rows[4]["Puntos"].ToString();

            puntuacion.valorRespuestas(Convert.ToInt32( dt.Rows[0]["Puntos"]), Convert.ToInt32( dt.Rows[1]["Puntos"]), Convert.ToInt32( dt.Rows[2]["Puntos"]), Convert.ToInt32( dt.Rows[3]["Puntos"]), Convert.ToInt32( dt.Rows[4]["Puntos"]));
        }

        public DataSet cargarPreguntas()//int categoria
        {
            DataSet respuesta = new DataSet();
            comando.Parameters.Clear();
            comando.Connection = cn1;
            /*SqlParameter Par_Nacion = comando.Parameters.Add("Categoria", SqlDbType.Int);
            Par_Nacion.Value = categoria;*/
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "verPreguntas";
            SqlDataAdapter lector = new SqlDataAdapter(comando);
            lector.Fill(respuesta);

            return respuesta;
        }

        //RONDA RESPUESTAS RAPIDAS:
        public void mostrarRespuestaRapidas(DataSet ds, RadioButton rb1, RadioButton rb2, RadioButton rb3, RadioButton rb4, RadioButton rb5, Label valor1, Label valor2, Label valor3, Label valor4, Label valor5)
        {
            DataTable dt = ds.Tables[0];                    
            //caja.Text = pregunta.SelectedItem.ToString();         
            rb1.Text = dt.Rows[0]["Respuestas"].ToString();
            rb2.Text = dt.Rows[1]["Respuestas"].ToString();
            rb3.Text = dt.Rows[2]["Respuestas"].ToString();
            rb4.Text = dt.Rows[3]["Respuestas"].ToString();
            rb5.Text = dt.Rows[4]["Respuestas"].ToString();
            valor1.Text= dt.Rows[0]["Puntos"].ToString();
            valor2.Text = dt.Rows[1]["Puntos"].ToString();
            valor3.Text = dt.Rows[2]["Puntos"].ToString();
            valor4.Text = dt.Rows[3]["Puntos"].ToString();
            valor5.Text = dt.Rows[4]["Puntos"].ToString();  
        }

        public void SumaPuntos(Label ver, int valor)//sumando puntos de las respuestas
        {
            puntuacion.acumulaPuntos(valor);
            ver.Text = puntuacion.totalPuntos().ToString();
        }

        public void PlayAudioCorrecto()
        {
            string ruta = "Audio/correcta.wav";
            SoundPlayer s = new SoundPlayer(ruta);
            s.Play();
        }//reproducir audio

        public void PlayAudioIncorrecto()
        {
            string ruta = "Audio/incorrecto.wav";
            SoundPlayer s = new SoundPlayer(ruta);
            s.Play();
        }//reproducir audio
    }//class
}//namespace