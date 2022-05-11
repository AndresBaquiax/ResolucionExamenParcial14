using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResolucionExamenParcial14
{
    public partial class _Default : Page
    {
        static List<Jugadores> listJugador = new List<Jugadores>();
        static List<Resultado> listResultado = new List<Resultado>(); 

        public void leer()
        {
            string fileName = Server.MapPath("~/Jugadores.txt");
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > - 1)
            {
                Jugadores objJugador = new Jugadores();
                objJugador.id = Convert.ToInt32(reader.ReadLine());
                objJugador.nombre = reader.ReadLine();
                objJugador.equipo = reader.ReadLine();
                listJugador.Add(objJugador);
            }
        }
        public void guardar()
        {
            string fileName = Server.MapPath("~/Goles.txt");
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var dato in listResultado)
            {
                writer.WriteLine(dato.idJug);
                writer.WriteLine(dato.fecha);
                writer.WriteLine(dato.equipo);
                writer.WriteLine(dato.goles);
            }
            writer.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            leer();
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = listJugador;
            DropDownList1.DataBind();
            DropDownList2.DataValueField = "equipo";
            DropDownList2.DataSource = listJugador;
            DropDownList2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Resultado objResultado = new Resultado();
            objResultado.idJug = Convert.ToInt32(DropDownList1.SelectedValue);
            objResultado.fecha = Calendar1.SelectedDate;
            objResultado.equipo = DropDownList2.SelectedValue;
            objResultado.goles = Convert.ToInt32(TextBox3.Text);
            listResultado.Add(objResultado);
            guardar();
        }
    }
}