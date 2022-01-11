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
    public partial class ConsultasForm : Form
    {
        public ConsultasForm()
        {
            InitializeComponent();

        }
        SqlConnection Con = new SqlConnection(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        private void ConsultasForm_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.Visible = !bunifuTextBox2.Visible;
            bunifuTextBox1.Visible = !bunifuTextBox1.Visible;
            bunifuTextBox3.Visible = !bunifuTextBox3.Visible;
            bunifuTextBox4.Visible = !bunifuTextBox4.Visible;
            bunifuTextBox5.Visible = !bunifuTextBox5.Visible;
            bunifuTextBox6.Visible = !bunifuTextBox6.Visible;
            bunifuTextBox7.Visible = !bunifuTextBox7.Visible;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            var sqlQuery = "Select Id, NomePaciente as Nome, TelPaciente as Telefone, CartPaciente as Carteirinha, Procedimento, Alergia, DataConsulta as Data, HoraConsulta as Hora From Consultas";
            Con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    Dataview.DataSource = dt;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void newform_Click(object sender, EventArgs e)
        {
            Cadastrar f3 = new Cadastrar();
            f3.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)

        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Con.Close();
            Con.Open();
            var sqlQuery = "SELECT * FROM Consultas WHERE NomePaciente like '" + search.Text + "%'";

            using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    Dataview.DataSource = dt;
                }
            }
        }
        public void Dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            search.Text = Dataview.SelectedRows[0].Cells[1].Value.ToString();
            bunifuTextBox1.Text = Dataview.SelectedRows[0].Cells[1].Value.ToString();
            bunifuTextBox2.Text = Dataview.SelectedRows[0].Cells[2].Value.ToString();
            bunifuTextBox3.Text = Dataview.SelectedRows[0].Cells[3].Value.ToString();
            bunifuTextBox4.Text = Dataview.SelectedRows[0].Cells[4].Value.ToString();
            bunifuTextBox5.Text = Dataview.SelectedRows[0].Cells[5].Value.ToString();
            bunifuTextBox6.Text = Dataview.SelectedRows[0].Cells[6].Value.ToString();
            bunifuTextBox7.Text = Dataview.SelectedRows[0].Cells[7].Value.ToString();




        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Consultas where NomePaciente=@nome", Con);
                    cmd.Parameters.AddWithValue("@nome", search.Text);
                    cmd.ExecuteNonQuery();
                    var sqlQuery = "Select * From Consultas";

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            Dataview.DataSource = dt;
                        }

                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Editxt_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Close();

                Con.Open();

                SqlCommand cmd = new SqlCommand("Update Consultas SET NomePaciente=@nome,TelPaciente =@tel, CartPaciente =@cart, Procedimento =@proc, Alergia =@alerg,DataConsulta =@data, HoraConsulta =@hora where Id =@ID", Con);
                cmd.Parameters.AddWithValue("@ID", search.Text);
                cmd.Parameters.AddWithValue("@nome", bunifuTextBox1.Text);
                cmd.Parameters.AddWithValue("@tel", bunifuTextBox2.Text);
                cmd.Parameters.AddWithValue("@cart", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@proc", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@alerg", bunifuTextBox5.Text);
                cmd.Parameters.AddWithValue("@data", bunifuTextBox6.Text);
                cmd.Parameters.AddWithValue("@hora", bunifuTextBox7.Text);
                MessageBox.Show("Consulta Editada!");




                cmd.ExecuteNonQuery();
                var sqlQuery = "Select * From Consultas";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        Dataview.DataSource = dt;
                    }

                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void timept_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Con.Close();
                Con.Open();
                var sqlQuery = "SELECT * FROM Consultas WHERE DataConsulta =  '" + timept.Value + "' ";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        Dataview.DataSource = dt;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void procpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Con.Close();
                Con.Open();
                var sqlQuery = "SELECT * FROM Consultas WHERE Procedimento =  '" + procpt.Text + "' ";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        Dataview.DataSource = dt;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnpaciente_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CadastrarPaciente f2 = new CadastrarPaciente();
            f2.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            CadastrarPaciente f3 = new CadastrarPaciente();
            f3.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Estoque f5 = new Estoque();
            f5.Show();
            this.Hide();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

