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
    
    public partial class Kullanıcı : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;
        public Kullanıcı()
        {
            InitializeComponent();
        }
        string masano;

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Hide();
            masano = "1";
            panel3.Show();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            button1.BackColor = Color.Red;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            masano = "2";
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            button1.BackColor = Color.Blue;
            button2.BackColor = Color.Red;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            masano = "3";
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            button1.BackColor = Color.Blue;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Red;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            masano = "4";
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            button1.BackColor = Color.Blue;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Red;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            masano = "5";
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            button1.BackColor = Color.Blue;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Red;
            button6.BackColor = Color.Blue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            masano = "6";
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
            button1.BackColor = Color.Blue;
            button2.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Red;
        }

        private void Kullanıcı_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (cGenel.masasayısı != 0)
            {
                int satir = 56;
                int sutun = 100;
                int sutunüst = 68;
                int satirüst = 61;
                for (int i = 0; i < cGenel.masasayısı; i++)
                {
                    int newSize = 15;
                    Button a = new Button();
                    a.Text = (i + 8).ToString();
                    a.Font = new Font(a.Font.FontFamily, newSize);
                    a.Size = new Size(62, 55);
                    a.Location = new Point(sutun, satir);
                    a.BackColor = Color.Blue;
                    this.Controls.Add(a);
                    satir += satirüst;

                    if (i == 5) { sutun += sutunüst; satir = 56; }
                    if (i == 11) { sutun += sutunüst; satir = 56; }
                }
            }
            panel4.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.Hide();
            listBox3.Hide();
            listBox4.Hide();

            string yemek = "Yemek";
            string içecek = "İçecek";
            string tatlı = "Tatlı";

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From Ürünler where stkkategori='"+yemek+"'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["stkismi"]);
            }
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From Ürünler where stkkategori='" + içecek + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["stkismi"]);
            }
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From Ürünler where stkkategori='" + tatlı + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["stkismi"]);
            }
            baglanti.Close();
            komut.Dispose();
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into Siparis (ürünadı,ürünadet,masano) values (@pürünadı, @pürünadet, @pmasano)";
            if (comboBox1.Text!="")
            {
                listBox2.Items.Add(comboBox1.Text);
                komut.Parameters.AddWithValue("@pürünadı", comboBox1.Text);
                komut.Parameters.AddWithValue("@pürünadet", comboBox4.Text);
                komut.Parameters.AddWithValue("@pmasano", masano);
            }
            if (comboBox2.Text != "")
            {
                listBox2.Items.Add(comboBox2.Text);
                komut.Parameters.AddWithValue("@pürünadı", comboBox2.Text);
                komut.Parameters.AddWithValue("@pürünadet", comboBox5.Text);
                komut.Parameters.AddWithValue("@pmasano", masano);
            }
            if (comboBox3.Text != "")
            {
                listBox2.Items.Add(comboBox3.Text);
                komut.Parameters.AddWithValue("@pürünadı", comboBox3.Text);
                komut.Parameters.AddWithValue("@pürünadet", comboBox6.Text);
                komut.Parameters.AddWithValue("@pmasano", masano);
            }
            
            
            

            komut.ExecuteNonQuery();
            baglanti.Close();
            komut.Dispose();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Hide();
            panel2.Show();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
            OleDbCommand komut = new OleDbCommand();
            
            
            OleDbDataReader dr;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From Siparis where masano='" + masano + "'";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["ürünadı"]);
            }
            baglanti.Close();
            komut.Dispose();
            int adet = 0;


            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select stkfiyat From Ürünler,Siparis  where masano='" + masano + "' AND Siparis.ürünadı=Ürünler.stkismi ";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox3.Items.Add(dr["stkfiyat"]);
                
            }
            baglanti.Close();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select ürünadet From Ürünler,Siparis   where masano='" + masano + "' AND Siparis.ürünadı=Ürünler.stkismi ";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox4.Items.Add(dr["ürünadet"]);
            }
            baglanti.Close();
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                adet += Convert.ToInt32(listBox3.Items[i]) * Convert.ToInt32(listBox4.Items[i]);
            }
            komut.Dispose();

            richTextBox2.Text = adet.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text=="")
            {
                MessageBox.Show("Lütfen Ödenen Tutarı Doldurunuz!");
            }
            else
            {
                label10.Text = Convert.ToString(Convert.ToInt32(richTextBox2.Text) - Convert.ToInt32(richTextBox3.Text));
                panel4.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
           panel2.Hide();
           
           OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
           OleDbCommand komut = new OleDbCommand();
           
           baglanti.Open();
           komut.Connection = baglanti;
           komut.CommandText = "Delete From Siparis Where masano='" + masano + "'";
           baglanti.Close();
           komut.Dispose();
           
           listBox2.Items.Clear();
           comboBox1.Text = "";
           comboBox2.Text = "";
           comboBox3.Text = "";
           comboBox4.Text = "";
           comboBox5.Text = "";
           comboBox6.Text = "";
           
           listBox1.Items.Clear();
           listBox3.Items.Clear();
           listBox4.Items.Clear();
           
           richTextBox2.Clear();
           richTextBox3.Clear();

           MessageBox.Show("Hesap Kapatıldı!");
           panel4.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel2.Show();
        }

        
    }
    public class cGenel
    {
        public static int masasayısı;
    }
}
