using EToolBE;
using EToolBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EToolForm
{
    public partial class FrmCargaRapida : Form
    {
        DataTable tabla1;
        Importar _Importar = new Importar();
        protected DataView dvDefectos;
        public FrmCargaRapida()
        {
            InitializeComponent();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            int m = 0;
            CapacitacionBE _CapacitacionBE = null;
            CapacitacionBL _CapacitacionBL = new CapacitacionBL();
            foreach (DataGridViewRow rowcurso in dgvExamen.Rows)
            {
                try
                {
                _CapacitacionBE = new CapacitacionBE();
                _CapacitacionBE.Legajo = Convert.ToInt32(dgvExamen.Rows[m].Cells["Legajo"].Value);
                _CapacitacionBE.IdEtto = dgvExamen.Rows[m].Cells["IdEtto"].Value.ToString();
                _CapacitacionBE.Fecha = Convert.ToDateTime(dgvExamen.Rows[m].Cells["Fecha"].Value);
                _CapacitacionBE.Nota = Convert.ToInt32(dgvExamen.Rows[m].Cells["Nota"].Value);
                _CapacitacionBE.Certificado = Convert.ToBoolean(dgvExamen.Rows[m].Cells["Certificado"].Value);
                 _CapacitacionBE.Id = Convert.ToInt32(dgvExamen.Rows[m].Cells["Id"].Value);
                _CapacitacionBL.InsertarCapacitacion(_CapacitacionBE);
                    }
                catch (SqlException x)
                {
                    dgvExamen.Rows[m].DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                    if(x.Number==2627)
                        MessageBox.Show("La evaluación ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    MessageBox.Show("Error, no se pudo registrar Fila /" + x.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch(Exception x)
                {
                    dgvExamen.Rows[m].DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                    MessageBox.Show("Error, no se pudo registrar Fila /" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                m++;

            }
            MessageBox.Show("Fin de carga rapida", "Estado", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            tabla1 = _Importar.traerExcel("Carga");
            dgvExamen.DataSource = tabla1;
        }
    }
}
