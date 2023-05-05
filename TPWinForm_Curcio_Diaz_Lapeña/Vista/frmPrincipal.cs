using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void listarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListar ventana = new frmListar();
            ventana.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar ventana = new frmAgregar();
            ventana.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("CONFIRMAR", "ELIMINAR ARTICULO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if(respuesta == DialogResult.Yes) {
                    seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.ID);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void cargar()
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                listaArticulo = articulo.listar();
                dgvArticulo.DataSource = listaArticulo;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
