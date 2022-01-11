using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaDentaria2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ConsultasForm f2 = new ConsultasForm();
            f2.Show();
            this.Hide();


        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count (*) from Paciente", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            labelpaciente.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count (*) from Consultas", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            consultas.Text = dt1.Rows[0][0].ToString();
            var sqlQuery = "Select NomePaciente as Nome, DataConsulta as Data, HoraConsulta as Hora From Consultas";
            Con.Close();
            Con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
            {
                using (DataTable dt2 = new DataTable())
                {
                    da.Fill(dt2);
                    Dataview.DataSource = dt2;
                }
            
        }


    }



    private void guna2Button1_Click(object sender, EventArgs e)
        {
            CadastrarPaciente f2 = new CadastrarPaciente();
            f2.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void consultas_Click(object sender, EventArgs e)
        {

        }

        private void labelpaciente_Click(object sender, EventArgs e)
        {

        }

        private void Dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Estoque f4 = new Estoque();
            f4.Show();
            this.Hide();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            Estoque f6 = new Estoque();
            f6.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login f8 = new Login();
            f8.Show();
            this.Hide();
        }
    }
}
