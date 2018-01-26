using EToolBE;
using EToolBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EToolWeb
{
    public partial class FrmCargaRapidaRegistrar : System.Web.UI.Page
    {
        EntrenamientoBL _EntrenamientoBL = new EntrenamientoBL();
        TBLUsuariosBL _TBLUsuariosBL = new TBLUsuariosBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToShortDateString();
                cargarComboEmpleado();
                cargarComboEntrenamiento();
            }
        }

        private void cargarComboEntrenamiento()
        {
            ddlEntrenamiento.DataSource = _EntrenamientoBL.ListarEntrenamiento_All();
            ddlEntrenamiento.DataValueField = "IdEtto";
            ddlEntrenamiento.DataTextField = "Entrenamiento";
            ddlEntrenamiento.DataBind();
            ddlEntrenamiento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void cargarComboEmpleado()
        {
            ddlEmpleado.DataSource = _TBLUsuariosBL.ListarTBLUsuario_Act();
            ddlEmpleado.DataValueField = "TNumber";
            ddlEmpleado.DataTextField = "Nombres";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
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
            CapacitacionBL _CapacitacionBL = new CapacitacionBL();
            CapacitacionBE _CapacitacionBE = new CapacitacionBE();
            _CapacitacionBE.IdEtto = ddlEntrenamiento.SelectedValue;
            _CapacitacionBE.Legajo = int.Parse(ddlEmpleado.SelectedValue);
            _CapacitacionBE.Fecha = Convert.ToDateTime(txtFecha.Text);
            _CapacitacionBE.Certificado = chbCertificado.Checked;
            _CapacitacionBE.Examen = msj;
            if(_CapacitacionBL.InsertarCapacitacion(_CapacitacionBE)>0)
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
                    guardarCapacitacion(msj);
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