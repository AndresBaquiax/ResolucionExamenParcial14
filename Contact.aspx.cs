using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResolucionExamenParcial14
{
    public partial class Contact : Page
    {
        static List<Jugadores> listJugador = new List<Jugadores>();
        static List<Resultado> listResultado = new List<Resultado>();
        static List<Combinacion> listOrdenar = new List<Combinacion>();
        public void leerJugador()
        {
            string fileName = Server.MapPath("~/Jugadores.txt");
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Jugadores objJugador = new Jugadores();
                objJugador.id = Convert.ToInt32(reader.ReadLine());
                objJugador.nombre = reader.ReadLine();
                objJugador.equipo = reader.ReadLine();
                listJugador.Add(objJugador);
            }
        }
        public void leerResultados()
        {
            string fileName = Server.MapPath("~/Goles.txt");
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Resultado objResultado = new Resultado();
                objResultado.idJug = Convert.ToInt32(reader.ReadLine());
                objResultado.fecha = Convert.ToDateTime(reader.ReadLine());
                objResultado.equipo = reader.ReadLine();
                objResultado.goles = Convert.ToInt32(reader.ReadLine());
                listResultado.Add(objResultado);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            leerJugador();
            leerResultados();

            for (int i = 0; i < listResultado.Count; i++)
            {
                for (int j = 0; j < listJugador.Count; j++)
                {
                    if (listResultado[i].idJug == listJugador[j].id)
                    {
                        Combinacion reporte = new Combinacion();
                        reporte.nombre = listJugador[j].nombre;
                        reporte.goles = listResultado[i].goles;
                        listOrdenar.Add(reporte);
                    }
                }
            }
            listOrdenar = listOrdenar.OrderBy(g => g.goles).ToList();
            GridView1.DataSource = listOrdenar;
            GridView1.DataBind();
            double promedio = listOrdenar.Average(g => g.goles);
            Label1.Text = promedio.ToString();
        }
    }
}