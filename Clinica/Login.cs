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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"xxxxxxxxxxxxxxxxxxxxxxxx");

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Con.Open();
            string query = "SELECT * FROM LOGIN WHERE Usuario = '" + lgn.Text + "' AND senha = '" + senha.Text + "' ";
            using (SqlDataAdapter da = new SqlDataAdapter(query, Con))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        Form1 f6 = new Form1();
                        f6.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou senha incorretos", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lgn.Text = "";
                        senha.Text = "";
                        lgn.Select();
                    }
                }
                Con.Close();
            }




        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jonasmanhezi");
        }
    }
}



