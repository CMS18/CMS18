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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Meddelande msg = new Meddelande();
            msg.Text = textBox1.Text;
            MessageBox.Show(msg.VisaMeddelande());
        }
    }
}
