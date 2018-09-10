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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Se debe ingresar un usuario.");
                return;
            }

            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar la contraseña.");
                return;
            }

            frmMenu principal = new frmMenu();
            if (principal.ValidarUsuarios(txtUsuario.Text, txtContraseña.Text))
            {
                MessageBox.Show("Ha iniciado sesión exitosamente.");
                this.Close();
            }
            else
            {
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                MessageBox.Show("Debe ingresar usuario y/o contraseña válido.");
            }
        }
    }
}
