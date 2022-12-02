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

namespace examen
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
          
        }
        static string chaine = @"Data Source=DESKTOP-PQOLN1N\SQLEXPRESS;Initial Catalog=mydatabase;Integrated Security=True";
        //"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\App_Data\VotreBD.mdf;Integrated Security=True;User Instance=True"
        //"Server=.\SQLEXPRESS; DataBase=VotreBD;USER ID=sa; PASSWORD="
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        private Binding data;

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idQuestion.Clear();
                 DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idExam.Text = row.Cells["id_Exam"].Value.ToString();
                enonce.Text = row.Cells["nom"].Value.ToString();
                idQuestion.Text = row.Cells["id_Question"].Value.ToString();
                
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.CommandText = "select * from Question";
            cmd.Connection = cnx;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.Enabled = true;
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id_Question";
           data =idQuestion.DataBindings.Add("text", comboBox1.DataSource, "id_Question");

            cmd.CommandText = "select * from Exam";
            cmd.Connection = cnx;
            DataTable db = new DataTable();
            adapter.Fill(db);
            dataGridView1.DataSource = db;
            dataGridView1.Columns.Add("select * from Question where id_Question=data", "id_Qcm");
          
            cnx.Close();





        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into Exam(id_Exam,nom,id_Question) values('" + idExam.Text + "','" + enonce.Text + "','" + idQuestion.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted");
            cnx.Close();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "delete from Exam where id_Exam='" + idExam.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            cnx.Close();
          
           
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "update Exam set nom ='" + enonce.Text + "', id_Question ='" + idQuestion.Text + "' where id_Exam='" + idExam.Text + "' ";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
    }
}
