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
    public partial class Rapor : Form
    {
        
        public Rapor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            OleDbCommand komut = new OleDbCommand();
            OleDbDataReader dr;
            if (radioButton1.Checked)
            {
                DateTime gün = DateTime.Today;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Select ürünadı,ürünadet,Tarih,stkismi,stkmaliyet,stkfiyat From Siparis,Ürünler ";
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    while (dr["Tarih"]==gün.ToString())
                    {
                        listBox1.Items.Add(dr["ürünadı"]);
                        listBox3.Items.Add(dr["ürünadet"]);
                    }

                }
                int adettoplam = 0;
                for (int i = 0; i <= listBox1.Items.Count; i++)
                {
                    while (dr.Read())
                    {
                        while (dr["ürünadı"]==listBox1.Items[i])
                        {
                            adettoplam += Convert.ToInt16(dr["ürünadet"]);
                            
                        }
                        while (dr["ürünadı"]==dr["stkisim"])
                        {
                            adettoplam *= Convert.ToInt32(dr["stkfiyat"]);
                        }
                        listBox4.Items.Add(adettoplam);
                        adettoplam = 0;
                    }
                }
                
                baglanti.Close();
                komut.Dispose();
                int toplam = 0;
                for (int i = 1; i <= listBox4.Items.Count; i++)
                {
                    toplam += Convert.ToInt32(listBox4.Items[i]);
                }
                label4.Text = toplam.ToString();
                /*
                baglanti.Open();
                komut.CommandText = "Select stkismi,stkmaliyet,stkfiyat From Ürünler";
                dr = komut.ExecuteReader();
                for (int i = 0; i < listBox1.Items.Count; i++)
			    {
                    textBox1.Text=listBox1.Items[i].ToString();

                    while (dr["stkisim"]==textBox1.Text)
                    {
                        listBox2.Items.Add(dr["stkfiyat"]);
                    }
			    }
                */

            }
            else if (radioButton2.Checked)
            {
                
            }
            else if (radioButton3.Checked)
            {

            }
            else
            {
                MessageBox.Show("Dikkat!","Lütfen Bir Seçim Yapın!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Rapor_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
