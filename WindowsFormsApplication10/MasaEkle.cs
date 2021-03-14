using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{

    public partial class MasaEkle : Form
    {
        
        public MasaEkle()
        {
            InitializeComponent();
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            cGenel.masasayısı = Convert.ToInt16(textBox1.Text);
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
