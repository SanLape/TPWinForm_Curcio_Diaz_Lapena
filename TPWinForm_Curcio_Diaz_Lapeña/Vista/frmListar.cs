using Negocio;
using Dominio;
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
    public partial class frmListar : Form
    {
        private List<Articulo> listaArticulo;
        public frmListar()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            listaArticulo = articulo.listar();
            dgvArticulo.DataSource = listaArticulo;
        }
    }
}
