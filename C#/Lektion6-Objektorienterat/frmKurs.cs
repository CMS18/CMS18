using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lektion6_Objektorienterat
{
    public partial class frmKurs : Form
    {
        public frmKurs()
        {
            InitializeComponent();
        }
        Kurs course = new Kurs();

        

        private void button1_Click(object sender, EventArgs e)
        {
            course.Course = textBox1.Text;
            course.Points = int.Parse(textBox2.Text);
            course.StartDate = dateTimePicker1.Text;
            course.EndDate = dateTimePicker2.Text;

            MessageBox.Show(course.Course +
                            "\n" +
                            course.Points +
                            "\n" +
                            course.StartDate +
                            "\n" +
                            course.EndDate);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double days = course.BeraknaAntalKursDagar();
            MessageBox.Show("Antal dagar: " + days);
        }
    }
}
