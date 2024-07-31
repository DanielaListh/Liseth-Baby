using Datos;
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


namespace Integrador
{
    public partial class ClienteEmpresa : Form
    {
        public ClienteEmpresa()
        {
            InitializeComponent();
 

        }


        private void btnBucar2_Click(object sender, EventArgs e)
        {
            

            try
            {
                DalClienteEmpresa objdal = new DalClienteEmpresa();
                DataSet objdataset = objdal.BuscarClienteEmpresa(Convert.ToInt32(txtId2.Text));
                int idIngresado = Convert.ToInt32(txtId2.Text);

                

                // Verifica si hay al menos una tabla en el DataSet
                if (objdataset.Tables.Count > 0 || idIngresado>0 )
                {
                    
                    // Llena el DataGridView con la primera tabla del DataSet
                    dgvEmpresa2.DataSource = objdataset.Tables[0];
                   
                    txtId2.Focus();
                    txtId2.Clear();
                    txtId2.Text = "ingrese un ID";
                    txtId2.ForeColor = Color.Gray;




                }
                else
                {
                    // No se encontraron resultados, podrías mostrar un mensaje o realizar alguna acción.
                    MessageBox.Show("No se encontraron resultados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }

        }

        
        
         ///////////////////////////////////////
         private void validarCampos()
        {
            var vr = !string.IsNullOrEmpty(txtNombre2.Text) && !string.IsNullOrEmpty(txtContacto2.Text) && !string.IsNullOrEmpty(txtCuit2.Text) && !string.IsNullOrEmpty(txtEmail2.Text) && !string.IsNullOrEmpty(txtTelefono2.Text) && !string.IsNullOrEmpty(txtDireccion2.Text);
            btnEliminar2.Enabled = vr;
            btnModificar2.Enabled = vr;
            btnAgregar2.Enabled = vr;
        }

        private void validCamposFaltantes()
        {

            lblNomb2.Visible = string.IsNullOrEmpty(txtNombre2.Text);
            lblNomb2.ForeColor = Color.Crimson;
            lblNomb2.BackColor = string.IsNullOrEmpty(txtNombre2.Text) ? Color.GhostWhite : SystemColors.Control;

            lblcontac2.Visible = string.IsNullOrEmpty(txtContacto2.Text);
            lblcontac2.ForeColor = Color.Crimson;
            lblcontac2.BackColor = string.IsNullOrEmpty(txtContacto2.Text) ? Color.GhostWhite : SystemColors.Control;

            lblcui2.Visible = string.IsNullOrEmpty(txtCuit2.Text);
            lblcui2.ForeColor = Color.Crimson;
            lblcui2.BackColor = string.IsNullOrEmpty(txtCuit2.Text) ? Color.GhostWhite : SystemColors.Control;

            lbltelef2.Visible = string.IsNullOrEmpty(txtTelefono2.Text);
            lbltelef2.ForeColor = Color.Crimson;
            lbltelef2.BackColor = string.IsNullOrEmpty(txtTelefono2.Text) ? Color.GhostWhite : SystemColors.Control;

            lbldirec2.Visible = string.IsNullOrEmpty(txtDireccion2.Text);
            lbldirec2.ForeColor = Color.Crimson;
            lbldirec2.BackColor = string.IsNullOrEmpty(txtDireccion2.Text) ? Color.GhostWhite : SystemColors.Control;

        }


        private void ClienteEmpresa_Load(object sender, EventArgs e)// prueba de botones y * para que no los muestre al cargar el form
        {

            btnEliminar2.Enabled = false;
            btnModificar2.Enabled = false;
            btnAgregar2.Enabled = false;

            lblNomb2.Enabled = false;
            lblcontac2.Enabled = false;
            lblcui2.Enabled = false;
            lbltelef2.Enabled = false;
            lbldirec2.Enabled = false;

           
        }
        ////////////////////////////////////////



        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            //obtener informacion

            if (string.IsNullOrWhiteSpace(txtNombre2.Text) || string.IsNullOrWhiteSpace(txtContacto2.Text) || string.IsNullOrWhiteSpace(txtCuit2.Text) || string.IsNullOrWhiteSpace(txtEmail2.Text) || string.IsNullOrWhiteSpace(txtTelefono2.Text) || string.IsNullOrWhiteSpace(txtDireccion2.Text))
            {
                MessageBox.Show("No pueden haber campos vacíos", "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //limpiarError();
            }
            else
            {
                try
                {
                    //btnEliminar2.Enabled = false;
                    //btnModificar2.Enabled = false;

                    DalClienteEmpresa odjdal = new DalClienteEmpresa();
                    odjdal.AgregarClienteEmpresa(Convert.ToInt32(txtId22.Text), txtNombre2.Text, txtContacto2.Text, txtCuit2.Text, txtEmail2.Text, txtTelefono2.Text, txtDireccion2.Text);

                    MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCamposProducto();
                    dgvEmpresa2.DataSource = null;    // limpiar grilla

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private void btnModificar2_Click(object sender, EventArgs e)
        {
            try
            {
                DalClienteEmpresa odjdal = new DalClienteEmpresa();
                odjdal.ModificarClienteEmpresa(Convert.ToInt32(txtId22.Text), txtNombre2.Text, txtContacto2.Text, txtCuit2.Text, txtEmail2.Text, txtTelefono2.Text, txtDireccion2.Text);

                MessageBox.Show("Cliente modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            try
            {
                Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();
                objdal.EliminarClienteEmpresa(Convert.ToInt32(txtId22.Text));

                MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void btnVerClienteEmpresa2_Click(object sender, EventArgs e)// ver todos los datos existentes en la tabla de base de datos
        {
            try
            {
                Datos.DalClienteEmpresa objdal = new Datos.DalClienteEmpresa();
                DataSet objdataset = objdal.BuscarClienteEmpresaTodos();

                if (objdataset.Tables.Count > 0)
                {
                    dgvEmpresa2.DataSource = objdataset.Tables[0];
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Datos de clientes de Empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LimpiarCamposProducto()
        {
            // limpia los campos y enfoca en el textBox2
            txtNombre2.Text = null;
            txtContacto2.Text = null;
            txtCuit2.Text = null;
            txtEmail2.Text = null;
            txtTelefono2.Text = null;
            txtDireccion2.Text = null;
            txtId2.Text = "ingrese un ID si desea buscar un Id especifico";
            txtId2.ForeColor = Color.Gray;//buscador

            txtNombre2.Focus();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtId2_KeyPress(object sender, KeyPressEventArgs e)// solo numeros
        {
            

            if ((e.KeyChar>=32 && e.KeyChar <= 47) || (e.KeyChar>=58 && e.KeyChar<=255))
            {
                MessageBox.Show("En este campo solo se admiten numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
            else
            {
                txtId2.Focus();
                txtId2.Clear();
                //txtId2.Text = "ingrese un ID";
                //txtId2.ForeColor = Color.Gray;
            }
        }

        private void txtId2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId22_TextChanged(object sender, EventArgs e)// se habilita el id cuando los campos estan llenos
        {

            var ve = !string.IsNullOrEmpty(txtNombre2.Text) ||
           !string.IsNullOrEmpty(txtContacto2.Text) ||
           !string.IsNullOrEmpty(txtCuit2.Text) ||
           !string.IsNullOrEmpty(txtTelefono2.Text) ||
           !string.IsNullOrEmpty(txtDireccion2.Text);

            txtId22.ReadOnly = ve;
        }

        private void txtNombre2_KeyPress(object sender, KeyPressEventArgs e)// solo letras
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("En este campo solo se admiten letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
        }

        private void txtNombre2_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void txtContacto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("En este campo solo se admiten letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
        }

        private void txtCuit2_KeyPress(object sender, KeyPressEventArgs e)// solo numeros y guiones
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 44) || (e.KeyChar >= 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("En este campo solo se admiten numeros y guiones", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
        }

        private void txtId22_KeyPress(object sender, KeyPressEventArgs e)// solo numeros
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("En este campo solo se admiten numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
        }

        private void txtTelefono2_KeyPress(object sender, KeyPressEventArgs e)//solo numero espaciado y +
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 42) || (e.KeyChar >= 44 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("En este campo solo se admiten numeros, espacios y simbolos '+' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // por convencion de caracteres ASCII
                return;
            }
        }

        private void btnExaminarFoto2_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectorImagen= new OpenFileDialog();//nos permite seleccionar archivo de carpetas
            SelectorImagen.Title = "Seleccionar imagen";
            if (SelectorImagen.ShowDialog()==DialogResult.OK)// cuando presiona ok
            {
                ipbFoto2.Image = Image.FromStream(SelectorImagen.OpenFile());// seleccionas la imagen en tus archivos locales, pero no hice la funcion de guardar con bbdd porque no me dio tiempo
            }
        }

       

        //validacion y prueba de desactivar botones si estos campos estan vacios
        private void txtNombre2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }

        private void txtContacto2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }

        private void txtCuit2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }

        private void txtEmail2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }

        private void txtTelefono2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }

        private void txtDireccion2_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
            validCamposFaltantes();
        }
    }
}