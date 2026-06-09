using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Subject> Subjects;
        public Subject Sub;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void SubName_TextChanged(object sender, EventArgs e)
        {
            Sub.Name = SubName.Text;
        }

        private void SubAdd_Click(object sender, EventArgs e)
        {
            Subjects.Add(Sub);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Subjects.Count; i++) 
            {
                dataGridView1.Rows.Add(Subjects[i].Name, Subjects[i].DateTime);
            }
        }

        private void SubDate_TextChanged(object sender, EventArgs e)
        {
            Sub.DateTime = SubName.Text;
        }
    }
}