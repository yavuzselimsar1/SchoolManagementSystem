using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            Student StudentInfo = new Student();
            StudentInfo.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.Show();
        }
    }
}
