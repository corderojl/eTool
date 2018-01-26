using EToolBE;
using EToolBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EToolWeb
{
    public partial class FrmCargaRapidaActualizar : System.Web.UI.Page
    {
        EntrenamientoBL _EntrenamientoBL = new EntrenamientoBL();
        TBLUsuariosBL _TBLUsuariosBL = new TBLUsuariosBL();
        CapacitacionBL _CapacitacionBL = new CapacitacionBL();
        CapacitacionBE _CapacitacionBE = new CapacitacionBE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id=Convert.ToInt32(Request.QueryString["id"]);
                _CapacitacionBE=_CapacitacionBL.TraerCapacitacion(id);
                txtFecha.Text = _CapacitacionBE.Fecha.ToShortDateString();
                txtNota.Text = _CapacitacionBE.Nota.ToString();
                chbCertificado.Checked = _CapacitacionBE.Certificado;
                lblId.Text = _CapacitacionBE.Id.ToString();
                cargarComboEmpleado(_CapacitacionBE.Legajo);
                cargarComboEntrenamiento(_CapacitacionBE.IdEtto);
                lblExamen.Text = _CapacitacionBE.Examen;
                if (_CapacitacionBE.Examen != null)
                {
                    string ext = Path.GetExtension(_CapacitacionBE.Examen);
                    if (ext != "")
                        if (ext != ".pdf")
                            ltlArchivo.Text = "<a title=\"" + _CapacitacionBE.Examen + "\" href=\"Examenes/" + _CapacitacionBE.Examen + "\"><img src=\"images/photos.png\" target=\"_blank\" alt=\"" + _CapacitacionBE.Examen + "\" width=\"50\" height=\"50\"/></a>";
                    else
                            ltlArchivo.Text = "<a title=\"" + _CapacitacionBE.Examen + "\" href=\"Examenes/" + _CapacitacionBE.Examen + "\"><img src=\"images/pdf.png\" target=\"_blank\" alt=\"" + _CapacitacionBE.Examen + "\" width=\"50\" height=\"50\"/></a>";
                } 
            }
        }

        private void cargarComboEntrenamiento(string IdEtto)
        {
            ddlEntrenamiento.DataSource = _EntrenamientoBL.ListarEntrenamiento_All();
            ddlEntrenamiento.DataValueField = "IdEtto";
            ddlEntrenamiento.DataTextField = "Entrenamiento";            
            ddlEntrenamiento.DataBind();
            ddlEntrenamiento.SelectedValue = IdEtto;
        }

        private void cargarComboEmpleado(int legajo)
        {
            ddlEmpleado.DataSource = _TBLUsuariosBL.ListarTBLUsuario_Act();
            ddlEmpleado.DataValueField = "TNumber";
            ddlEmpleado.DataTextField = "Nombres";
            ddlEmpleado.DataBind();
            ddlEmpleado.SelectedValue = legajo.ToString();
        }

        private string subirArchivo()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Examenes/");
            string mensaje;
            if (fupExamen.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(fupExamen.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        fupExamen.PostedFile.SaveAs(path
                            + fupExamen.FileName);
                        return mensaje = fupExamen.FileName;

                    }
                    catch (Exception ex)
                    {
                        return mensaje = "Error";
                    }
                }
                else
                {
                    return mensaje = "Formato";
                }
            }
            else
                return "";

        }

        private void guardarCapacitacion(string msj)
        {
            CapacitacionBE _ObeCapacitacionBE = new CapacitacionBE();
            int vid=-1;
            _ObeCapacitacionBE.IdEtto = ddlEntrenamiento.SelectedValue;
            _ObeCapacitacionBE.Legajo = int.Parse(ddlEmpleado.SelectedValue);
            _ObeCapacitacionBE.Fecha = Convert.ToDateTime(txtFecha.Text);
            _ObeCapacitacionBE.Certificado = chbCertificado.Checked;
            _ObeCapacitacionBE.Examen = msj;
            _ObeCapacitacionBE.Nota = int.Parse(txtNota.Text);
            _ObeCapacitacionBE.Id = int.Parse(lblId.Text);
            if(_CapacitacionBL.ActualizarCapacitacion(_ObeCapacitacionBE))
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ocurrió un error al guardar registro')", true);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string msj;
            msj = subirArchivo();
            switch (msj)
            {
                case "":
                    guardarCapacitacion(lblExamen.Text);
                    break;
                case "Error":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al subir archivo')", true);
                    break;
                case "Formato":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tipo de archivo no valido')", true);
                    break;
                default:
                    guardarCapacitacion(msj);                   
                    break;
            }
        }

    }
}