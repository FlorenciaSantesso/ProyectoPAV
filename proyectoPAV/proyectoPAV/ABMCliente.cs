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
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {
            //hay que deshabilitar los campos txt 
            deshabilitarCajasTexto();

            //DEShabilitar los botones que no necesito
            cmdEliminar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdGuardar.Enabled = false;
            //cargo combos
            //Ciudad
            cargoCiudades();
            //creo una tabla y voy llenando sus filas con los campos que traigo desde la bdd.
            

            //esto deberia cargar nuestra tabla local
            DataTable tabla = oDatos.consultarTabla("Cliente");
            lstClientes.DataSource = tabla;
            lstClientes.ValueMember = tabla.Columns[0].ColumnName;
            lstClientes.DisplayMember = "n_usuario";
        }
        private void deshabilitarCajasTexto()
            {
            //todos menos ID
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
                txtCUIT.Enabled = false;
                txtDireccion.Enabled = false;
                txtCodPostal.Enabled = false;
                txtTelefono.Enabled = false;
                txtMail.Enabled = false;
                }
        private void cargoCiudades()
            {
                DataTable tabla = oDatos.consultarTabla("Ciudad");
                cboCiudad.DataSource = tabla;
                cboCiudad.valueMember = tabla.Columns[0].ColumnName;
                cboCiudad.DisplayMember = tabla.Columns[1].ColumnName;
        }
        private void habilitarCajasTexto()
        {
            //todos menos ID
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtCUIT.Enabled = true;
            txtDireccion.Enabled = true;
            txtCodPostal.Enabled = true;
            txtTelefono.Enabled = true;
            txtMail.Enabled = true;
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            limpiarCliente();
        }
        private void  limpiarCliente()
        {
            txtApellido.Text= string.Empty;
            txtNombre.Text = string.Empty;
            txtCUIT.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtMail.Text = string.Empty;
            cboCiudad.TabIndex = -1;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            //deberia existir un metodo validar()
            if validarClienteExistente() == false
            {
                MessageBox("El cliente ya esta cargado");
                return;
            }
            if (nuevo == true) 
            {
              //insert
            //la " y ' se usan para cuando se usan Text
            string sql = "insert into Cliente (id,CUIT,nombre,apellido ,direccion,cod_postal,id_ciudad,telefono,id_cond_IVA,mail) values ("
                                            + "'" + txtId.Text + "','"
                                            + "'" + txtCUIT.Text + "','"
                                            + "'" + txtNombre.Text + "',"
                                            + "'" + txtApellido.Text + "',"
                                            + "'" + txtDireccion.Text + "',"
                                            + "'" + txtCodPostal.Text + "',"
                                            + "'" + cboCiudad.TabIndex + "',"
                                            + "'" + txtTelefono.Text + "',"
                                            + "'" + txtCodPostal.Text + "',"
                                            + "'" + cboCondIVA.TabIndex + "'," //cond iva
                                            + "'" + txtMail.Text + "')";
            }
            else
            //{   
            //update
            //}
            //nuevo=false;
            //actualizarLista()
            //poner un cartel q avise q ya se grabo o modifico
            //como ya grabe tengo q volver al mismo estado incial:
            //hay que deshabilitar los campos txt 
            //habilitar los botones que no necesito

            //hay q verificar si el q estoy grabando es un usuario nuevo o alguno q estoy modificando, lo puedo hacer a traves de una bandera
        }
        private bool validarCliente()
            //hay que ver cuales pueden ser null y cual no
        {
            if (txtApellido.Text != string.Empty)
            {
                Message("Ingrese Apeliido");
                return false;
            }
            if (txtNombre.Text != string.Empty)
            {
                MessageBox("Ingrese Nombre");
                return false;
            }
            return true;
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

        }    
        private void validarClienteExistente(int id)
        {
            string sql = "Select id  from Cliente where id = " + "'" + txtId.Text + "'";
            BDHelper.
          

        }
    }
}
