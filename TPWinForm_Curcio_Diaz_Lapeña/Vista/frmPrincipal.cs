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
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

            cboCrit.Items.Add("Comienza con");
            cboCrit.Items.Add("Termina con ");
            cboCrit.Items.Add("Contiene");

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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo art;
            art = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            frmAgregar modificar = new frmAgregar(art);
            modificar.ShowDialog();
            cargar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCrit.SelectedItem.ToString();

                string filtro = txtFiltroAvanzado.Text;

                dgvArticulo.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            */
            

        }

        private void lblBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               

           
        }

        private void dgvArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
