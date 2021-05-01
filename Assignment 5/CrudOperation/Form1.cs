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



namespace CrudOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String ConnectionString = @"Data Source=DESKTOP-LC08KE6\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";



        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            String name = textBox1.Text;
            String address = textBox2.Text;
            String gender = comboBox1.Text;
            String branch = comboBox2.Text;
            int finalsemMarks = int.Parse(textBox3.Text);
            int contactNo = int.Parse(textBox4.Text);
            DateTime joiningDate = DateTime.Parse(dateTimePicker1.Text);


            SqlCommand c = new SqlCommand("InsertStud_sp", conn);
            
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.Parameters.AddWithValue("@Name", name);
            c.Parameters.AddWithValue("@Address", address);
            c.Parameters.AddWithValue("@Gender", gender);
            c.Parameters.AddWithValue("@Branch", branch);
            c.Parameters.AddWithValue("@FinalMarks", finalsemMarks);
            c.Parameters.AddWithValue("@ContactNo", contactNo);
            c.Parameters.AddWithValue("@JoiningDate", joiningDate);
            c.ExecuteNonQuery();

            MessageBox.Show("Successfully Inserted....");
            GetStudList();
        }
        void GetStudList()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            String SQL = " Select * from Student_Details ";

            SqlDataAdapter sd = new SqlDataAdapter(SQL, conn);
            DataSet ds = new DataSet();
            sd.Fill(ds, "Student_Details");

            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student_Details";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // update
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            String name = textBox1.Text;
            String address = textBox2.Text;
            String gender = comboBox1.Text;
            String branch = comboBox2.Text;
            int finalsemMarks = int.Parse(textBox3.Text);
            int contactNo = int.Parse(textBox4.Text);
            DateTime joiningDate = DateTime.Parse(dateTimePicker1.Text);


            SqlCommand c = new SqlCommand("UpdateStud_sp", conn);

            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.Parameters.AddWithValue("@Name", name);
            c.Parameters.AddWithValue("@Address", address);
            c.Parameters.AddWithValue("@Gender", gender);
            c.Parameters.AddWithValue("@Branch", branch);
            c.Parameters.AddWithValue("@FinalMarks", finalsemMarks);
            c.Parameters.AddWithValue("@ContactNo", contactNo);
            c.Parameters.AddWithValue("@JoiningDate", joiningDate);
            c.ExecuteNonQuery();

            MessageBox.Show("Successfully Inserted....");
           
            GetStudList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
         
            
                int finalsemMarks = int.Parse(textBox3.Text);
                SqlCommand c = new SqlCommand("DeleteStud_sp", conn);
                c.CommandType = System.Data.CommandType.StoredProcedure;
                c.Parameters.AddWithValue("@FinalMarks", finalsemMarks);
                c.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted....");
              
                GetStudList();
            
        }

        
    }
}
