using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication10
{
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        OleDbCommand komut= new OleDbCommand();
        DataSet verikumesi= new DataSet();

        //Veritabanından alıp GridView nesnesine akataracak
        void VeriDoldur()
        {
            baglanti.Open();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("Select * from Ürünler", baglanti);
            adaptor.Fill(verikumesi, "Ürünler");
            dataGridView1.DataSource= verikumesi.Tables["Ürünler"];
            baglanti.Close();
        }
        

        private void Stok_Load(object sender, EventArgs e)
        {
            VeriDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&&textBox2.Text!="")
            {
                if (textBox3.Text !=""&& textBox4.Text!="")
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into Ürünler (stkismi, stkkategori, stkmaliyet,stkfiyat) values (@pstkismi, @pstkkategori, @pstkmaliyet, @pstkfiyat)";

                    komut.Parameters.AddWithValue("@pstkisim", textBox1.Text);
                    komut.Parameters.AddWithValue("@pstkkategori", textBox2.Text);
                    komut.Parameters.AddWithValue("@pstkmaliyet", textBox3.Text);
                    komut.Parameters.AddWithValue("@pstkfiyat", textBox4.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    verikumesi.Clear();
                    VeriDoldur();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
            else
            {
                MessageBox.Show("Dikkat!"+" "+"Lütfen Alanlarda Boş Yer Bırakmayın");

            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText="Delete from Ürünler where stkismi='"+ textBox1.Text +"'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();

                verikumesi.Clear();
                VeriDoldur();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Dikkat!"+" "+"Lütfen Bir İsim Yazın");
            }
        }
    }
}
