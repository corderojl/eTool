using EToolBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EToolWeb
{
    public partial class FrmCargaRapidaList : System.Web.UI.Page
    {
        EntrenamientoBL _EntrenamientoBL = new EntrenamientoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime hoy = DateTime.Today;

                txtFechaIni.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                txtFechaFin.Text = hoy.ToShortDateString(); 
                cargarComboEntrenamiento();
            }
        }
        private void cargarComboEntrenamiento()
        {
            ddlEntrenamiento.DataSource = _EntrenamientoBL.ListarEntrenamiento_All();
            ddlEntrenamiento.DataValueField = "IdEtto";
            ddlEntrenamiento.DataTextField = "Entrenamiento";
            ddlEntrenamiento.DataBind();
            ddlEntrenamiento.Items.Insert(0, new ListItem("Todo los Entrenamientos..", "%%"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            crearTabla(txtEmpleado.Text, ddlEntrenamiento.SelectedValue,Convert.ToDateTime(txtFechaIni.Text),Convert.ToDateTime(txtFechaFin.Text));
           
        }

        private void crearTabla(string Nombres, string IdEtto, DateTime FechaIni, DateTime FechaFin)
        {
             CapacitacionBL _CapacitacionBL = new CapacitacionBL();
             //gvCapacitaciones.DataSource = _CapacitacionBL.ListarCapacitacionFind(Nombres, IdEtto, FechaIni, FechaFin);
             //gvCapacitaciones.DataBind();

             DataTable Resultados = _CapacitacionBL.ListarCapacitacionFind(Nombres, IdEtto, FechaIni, FechaFin);
             StringBuilder Tabla = new StringBuilder();

             string id;

             int TotalRegistros = Resultados.Rows.Count;
             Tabla.AppendLine("<table class=\"table table-hover\">");
             Tabla.AppendLine("<thead>");
             Tabla.AppendLine("<th><a href=\"#\" onClick=\"PopUp('FrmCargaRapidaRegistrar.aspx',20,20,500,500); return false;\">Agregar</th><th>Entrenamiento</th><th> Nombres </th><th> Fecha </th><th> Nota </th><th> Certificado </th><th> Examen </th>");
             Tabla.AppendLine("</thead>");
             Tabla.AppendLine("<tbody>");

             for (int i = 0; i < TotalRegistros; i++)
             {
                 id = Resultados.Rows[i]["id"].ToString();
                 Tabla.AppendLine("<tr>");
                 Tabla.Append("<td><a href=\"#\" onClick=\"PopUp('FrmCargaRapidaActualizar.aspx?id=" + id + "',20,20,500,550); return false;\"> Editar </a></td>");
                 Tabla.Append("<td align=\"left\">" + Resultados.Rows[i]["Entrenamiento"].ToString() + "</td>");
                 Tabla.Append("<td>" + Resultados.Rows[i]["Nombres"].ToString() + "</td>");
                 Tabla.Append("<td>" + Resultados.Rows[i]["Fecha"] + "</td>");
                 Tabla.Append("<td>" + Resultados.Rows[i]["Nota"] + "</td>");
                 Tabla.Append("<td>" + Resultados.Rows[i]["Certificado"] + "</td>");
                 Tabla.Append("<td>" + Resultados.Rows[i]["Examen"] + "</td>");
                 Tabla.Append(Environment.NewLine);
                 Tabla.AppendLine("</tr>");
             }

             Tabla.AppendLine("</tbody>");
             Tabla.AppendLine("</table>");
             ltlCapacitaciones.Text = Tabla.ToString();
        }

    }
}