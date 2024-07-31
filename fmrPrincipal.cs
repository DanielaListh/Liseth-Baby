using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;



namespace Integrador
{
    public partial class fmrPrincipal : Form
    {
        public fmrPrincipal()
        {
            InitializeComponent();
            leftBorderBtn=new Panel();
            leftBorderBtn.Size = new Size(8, 66);
            pnlMenu1.Controls.Add(leftBorderBtn);


            //BARRA DE FORM
            this.Text=string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; //el tama;o de el form no interrumpa las otras ballas de tarea


        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        

        private struct RGBColors
        {
                public static System.Drawing.Color Color1= System.Drawing.Color.FromArgb(249,118,176);
                
        }

        private void ActivateButton(object senderBtn, System.Drawing.Color color )
        {
            if (senderBtn!=null)
            {
                DesactivarBoton();

                currentBtn=(IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = System.Drawing.Color.HotPink;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = System.Drawing.Color.LightPink;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign= ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location=new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                IconHome.IconChar=currentBtn.IconChar;
                IconHome.IconColor = color;
            }
        }

        private void DesactivarBoton()
        {
            if (currentBtn!=null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(255,255,255);//probemos
                currentBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.LightSkyBlue;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }


        private void fmrPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconLogOut_Click(object sender, EventArgs e)// cerrar secion
        {
            Login sesion=new Login();
            sesion.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)// cerrar programa
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        private void btnCliente_Click(object sender, EventArgs e)//evento click para Cliente Individuo
        {
            ActivateButton(sender, RGBColors.Color1);
            abrirFormularioHijo(new ClienteIndividuo());
            if (currentFormHijoClienteIndividuo == null || currentFormHijoClienteIndividuo.IsDisposed)
            {
                currentFormHijoClienteIndividuo = new ClienteIndividuo();
                currentFormHijoClienteIndividuo.Owner = this; // Establece el formulario principal como propietario del formulario hijo
            }

            currentFormHijoClienteIndividuo.Show();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color1);
            abrirFormularioHijo(new ClienteEmpresa());
        }

        private void btnProductos_Click(object sender, EventArgs e)// Establece el formulario principal como propietario del formulario hijo
        {
            ActivateButton(sender, RGBColors.Color1);
            abrirFormularioHijo(new Productos());
        }

        private void iconButton4_Click(object sender, EventArgs e)//no puedo cambiar el nombre o se me cae el form
        {
            ActivateButton(sender, RGBColors.Color1);
            abrirFormularioHijo(new Vendedores());
        }

        private void iconButton5_Click(object sender, EventArgs e)//no puedo cambiar el nombre o se me cae el form, Falta resolver
        {
            ActivateButton(sender, RGBColors.Color1);
            abrirFormularioHijo(new Configuracion());
        }

        private void pnlLogo1_Paint(object sender, PaintEventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            DesactivarBoton();
            leftBorderBtn.Visible = false;
            IconHome.IconChar = IconChar.Home;
            IconHome.IconColor = System.Drawing.Color.LightPink;
            lblHome.Text = "Home";
        }

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)//mover el form teniendo selecionado la balla de panel superior
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void abrirFormularioHijo(Form FormHijo)
        {
            if (currentFormHijo!=null)
            {
                currentFormHijo.Close();//al abrir un formulario, cerramos el anterior
            }
            currentFormHijo = FormHijo;
            FormHijo.TopLevel = false;//decimos que ese formulario no es de primer nivel
            FormHijo.Dock = DockStyle.Fill;
            FormHijo.FormBorderStyle = FormBorderStyle.None;


            pnlEscritorio.Controls.Add(FormHijo);//Agregamos formHijo a los controles del panel de escritorio
            pnlEscritorio.Tag = FormHijo;
            FormHijo.BringToFront();//traemos al frente 
            FormHijo.Show();
            lblHome.Text = FormHijo.Text; //mostramos etiqueta titulo
        }

        private void fmrPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Campos de clase
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentFormHijo;
        private ClienteIndividuo currentFormHijoClienteIndividuo;

        private void IconHome_Click(object sender, EventArgs e)//cuando hago clic en icon home current hijo se cierra
        {
            Reset();
            currentFormHijo.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if(WindowState== FormWindowState.Normal)//si la ventana esta en tama;o normal
            {
                WindowState = FormWindowState.Maximized;//se maximiza
            }
            else
            {
                WindowState= FormWindowState.Normal;//si esta la ventana maximizada entonces se hara normal
            }
        }

        private void pnlEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
