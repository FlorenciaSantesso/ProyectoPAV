using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPAV
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }
        public bool ValidarUsuarios(string pUsuario, string pContraseña)
        {
            BDHelper helper = new BDHelper();
            DataTable tabla = helper.ConsultaSQL("SELECT * FROM USERS WHERE n_usuario =  \'"
                            + pUsuario + "\' AND password = \'"
                            + pContraseña + "\'");
            //cambiar n_usuario y password por lo q pongamos nosotros en la BDD

            
            if (tabla.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?",
                "Salir",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)
                == DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
 
    }
}
