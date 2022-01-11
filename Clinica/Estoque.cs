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
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        private void Estoque_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            var sqlQuery = "Select ID, Item, Quantidade as Qtd, Data From Estoque";
            Con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    Dataview.DataSource = dt;
                }
            }
            Con.Close();
            Con.Open();
            var sqlQuery1 = "Select Id, Item, Quantidade as Qtd, DataRegistro as Data From Registro";

            using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery1, Con))
            {
                using (DataTable dp = new DataTable())
                {
                    da.Fill(dp);
                    datagrid1.DataSource = dp;
                }

            }
        }

        private void Dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idprod.Text = Dataview.SelectedRows[0].Cells[0].Value.ToString();
            prod.Text = Dataview.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void newform_Click(object sender, EventArgs e)
        {
            Random numeroID = new Random();
            numeroID.Next();

            try
            {
                Con.Close();
                Con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Registro(Id,Item,Quantidade,DataRegistro)values(@Id,@item,@qtd,@data)", Con);
                cmd.Parameters.AddWithValue("@Id", numeroID.Next());
                cmd.Parameters.AddWithValue("@item", prod.Text);
                cmd.Parameters.AddWithValue("@qtd", qtd.Text);
                cmd.Parameters.AddWithValue("@data", data.Value.Date);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Adicionado");
                SqlCommand cmd1 = new SqlCommand("Update Estoque SET Quantidade= Quantidade - @qtd where Id =@Id AND Quantidade > 0", Con);
                cmd1.Parameters.AddWithValue("@Id", idprod.Text);
                cmd1.Parameters.AddWithValue("@qtd", qtd.Text);
                cmd1.ExecuteNonQuery();
                var sqlQuery = "Select * From Registro ";
                var sqlQuery2 = "Select * From Estoque ";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                {
                    using (DataTable dp = new DataTable())
                    {
                        da.Fill(dp);
                        datagrid1.DataSource = dp;
                    }
                    using (SqlDataAdapter dl = new SqlDataAdapter(sqlQuery2, Con))
                    {
                        using (DataTable ds = new DataTable())
                        {
                            dl.Fill(ds);
                            Dataview.DataSource = ds;
                        }





                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

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

        private void Editxt_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Registro where Id =@id", Con);
                    cmd.Parameters.AddWithValue("@id", idprod.Text);
                    cmd.ExecuteNonQuery();
                    var sqlQuery = "Select * From Registro";

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            datagrid1.DataSource = dt;
                        }

                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void datagrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idprod.Text = datagrid1.SelectedRows[0].Cells[0].Value.ToString();
            prod.Text = datagrid1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ConsultasForm f2 = new ConsultasForm();
            f2.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CadastrarPaciente f3 = new CadastrarPaciente();
            f3.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void data_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Con.Close();
                Con.Open();
                var sqlQuery = "SELECT * FROM Registro WHERE DataRegistro =  '" + data.Value + "' ";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        datagrid1.DataSource = dt;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ConsultasForm f7 = new ConsultasForm();
            f7.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login f9 = new Login();
            f9.Show();
            this.Hide();
        }
    }
    }
    
