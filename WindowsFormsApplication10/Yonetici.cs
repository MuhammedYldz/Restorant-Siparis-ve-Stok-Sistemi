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
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasaEkle masalar = new MasaEkle();
            
            
            masalar.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KullanıcıEkle Kullanıcı = new KullanıcıEkle();
            
            Kullanıcı.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stok stoklar = new Stok();
            
            stoklar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rapor raporla = new Rapor();
            
            raporla.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
        }
    }
}
