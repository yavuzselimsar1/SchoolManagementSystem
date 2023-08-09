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

namespace SchoolManagementSystem
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-T48PO58;Initial Catalog=schooldb;Integrated Security=True;");
        private void BtnSave_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("Insert into studentab  (Id,Name,Email,Phone) values (@Id,@Name,@Email,@Phone)", con);
                cnn.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox1.Text));
                cnn.Parameters.AddWithValue("@Name", textBox2.Text);
                cnn.Parameters.AddWithValue("@Email", textBox3.Text);
                cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved");
            }
            catch 
            {

                MessageBox.Show("Data Not Saved");
            }
            

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {          
            SqlCommand cnn = new SqlCommand("Select * from studentab",con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("Update studentab set Name=@Name,Email=@Email,Phone=@Phone where Id=@Id", con);

                cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Name", textBox2.Text);
                cnn.Parameters.AddWithValue("@Email", textBox3.Text);
                cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated");
            }
            catch 
            {
                MessageBox.Show("Data Not Updated");

            }
                               
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("Delete from studentab where Id=@Id", con);

                cnn.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted");
            }
            catch 
            {
                MessageBox.Show("Data Not Deleted");

            }
            
        }
        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("Select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
