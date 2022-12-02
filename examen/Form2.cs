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

namespace examen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private const string V = "Qcm";
        static string chaine = @"Data Source=DESKTOP-PQOLN1N\SQLEXPRESS;Initial Catalog=mydatabase;Integrated Security=True";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        private void Form2_Load(object sender, EventArgs e)
        {
            typeQuestion();


        }

        private void confirm_Click(object sender, EventArgs e)
        {
           
        
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into Qcm(nom,id_Qcm,optionOne,optionTwo,optionThree) values('" + enonce.Text + "','" + idQcm.Text + "','" + optionone.Text + "','" + optiontwo.Text + "','" + optiontree.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted");
            cnx.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into Question(id_Question,nom,idQcm) values('" + id_Question.Text + "','" + nom.Text + "','" + idQc.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted");
            cnx.Close();
    

        }

        private void testBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into ouverte(nom,id_dicotomie,reponse) values('" + nomOverte.Text + "','" + idOuverte.Text + "','" + reponseOuverte.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted");
            cnx.Close();
        }

        private void typeText_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void typeQuestion()
        {
            if (typeText.Text == "Qcm")
            {
                cnx.Open();
                cmd.CommandText = "select * from Qcm";
                cmd.Connection = cnx;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.Enabled = true;
                comboBox1.DisplayMember = "nom";
                comboBox1.ValueMember = "id_Qcm";
                idQcm.DataBindings.Clear();
                optionone.DataBindings.Clear();
                optiontwo.DataBindings.Clear();
                optiontree.DataBindings.Clear();
                idQc.DataBindings.Add("text", comboBox1.DataSource, "id_Qcm");
                cnx.Close();
            }
            else 
            {
                cnx.Open();
                cmd.CommandText = "select * from ouverte";
                cmd.Connection = cnx;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.Enabled = true;
                comboBox1.DisplayMember = "nom";
                comboBox1.ValueMember = "id_dicotomie";
                idQcm.DataBindings.Clear();
                optionone.DataBindings.Clear();
                optiontwo.DataBindings.Clear();
                optiontree.DataBindings.Clear();
                idQc.DataBindings.Add("text", comboBox1.DataSource, "id_dicotomie");
                cnx.Close();
            }
            

        }
    }
   

}
