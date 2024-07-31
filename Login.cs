using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;



namespace Integrador
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam); //para mover las pantallas


        private void login()// metodo del procedimiento de la validacion del usuario en el login
        {
            SqlConnection conexion=new SqlConnection("Data Source=DESKTOP-HRRFN10\\SQLEXPRESS;Initial Catalog=KylieBabyDB;Integrated Security=True");

            conexion.Open();
            SqlCommand command = new SqlCommand("select login, password from Usuarios where login='" + textUser.Text + "' and password='" +txtPass.Text+"'",conexion );
            SqlDataReader datareader=command.ExecuteReader();


            if(datareader.Read())
            {
                Login login1 = new Login();
                MessageBox.Show("Login Exitoso ", "Sistema");
                fmrPrincipal frm = new fmrPrincipal();
                frm.Show();
                login1.Hide();
                this.Hide();
                
            }
            else
            {
                DialogResult respuesta=MessageBox.Show("Login Fallido, puede que te hayas equivocado al ingresar los datos. ", "Datos erroneos", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (respuesta == DialogResult.Cancel)
                {
                    textUser.Clear();
                    txtPass.Clear();
                    textUser.Focus();
                }
                else
                {
                    if(respuesta == DialogResult.Retry)
                    {
                        intentos++;
                        textUser.Clear();
                        txtPass.Clear();
                        textUser.Focus();
                        if (intentos == 3)
                        {
                            MessageBox.Show("Superaste la cantidad permitida de intentos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                        

                    }
                }
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtLegajo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1Buscar_Click(object sender, EventArgs e)
        {
          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//mover el formulario
        {
            //if(e.Button != MouseButtons.Left)
            //{
            //    xClick = e.X; yClick=e.Y;
            //    //donde X es left e Y sera top
            //}
            //else
            //{
            //    this.Left = this.Left + (e.X);
            //    this.Top=this.Top + (e.Y);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //campos de clase 
        // public int xClick, yClick;
        int intentos = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textUser_Enter(object sender, EventArgs e)
        {
            if (textUser.Text == "User")
            {
                textUser.Text = "";
                textUser.ForeColor = Color.PaleVioletRed;
               

            }
        }

        private void textUser_Leave(object sender, EventArgs e)
        {
            if(textUser.Text == "")
            {
                textUser.Text = "User";
                textUser.ForeColor = Color.DimGray;
            }
        }

        private void texPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.PaleVioletRed;
                
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)//si le cambio nombre a login da error
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // donde puedo poner el cierre de la conexion?
    }
}
