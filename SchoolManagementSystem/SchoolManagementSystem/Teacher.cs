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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolManagementSystem
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-T48PO58;Initial Catalog=schooldb;Integrated Security=True;");
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("Insert into teachertab (Name,Age,Gender) values (@name,@age,@gender)", con);

                cnn.Parameters.AddWithValue("@Name", textBox1.Text);
                cnn.Parameters.AddWithValue("@Age", int.Parse(textBox2.Text));
                cnn.Parameters.AddWithValue("Gender", comboBox1.Text);
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
            SqlCommand cnn = new SqlCommand("Select * from teachertab", con);
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
                SqlCommand cnn = new SqlCommand("Update teachertab set Age=@Age,Gender=@Gender where Name=@Name", con);

                cnn.Parameters.AddWithValue("@Name", textBox1.Text);
                cnn.Parameters.AddWithValue("@Age", int.Parse(textBox2.Text));
                cnn.Parameters.AddWithValue("Gender", comboBox1.Text);
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
                SqlCommand cnn = new SqlCommand("Delete teachertab where Name=@Name", con);

                cnn.Parameters.AddWithValue("@Name", textBox1.Text);

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
            SqlCommand cnn = new SqlCommand("Select * from teachertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
