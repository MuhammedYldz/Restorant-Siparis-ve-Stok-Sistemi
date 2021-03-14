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
    public partial class KullanıcıEkle : Form
    {
        OleDbConnection baglanti= new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
        OleDbDataAdapter adaptor= new OleDbDataAdapter();
        OleDbCommand komut= new OleDbCommand();
        DataSet verikumesi= new DataSet()  ;
        OleDbDataReader dr ;
        //Veritabanından alıp GridView nesnesine akataracak
        void VeriDoldur()
        {
            baglanti.Open();
          OleDbDataAdapter adaptor = new OleDbDataAdapter("Select * from Kullanıcılar", baglanti);
          verikumesi = new DataSet();
          
          adaptor.Fill(verikumesi, "Kullanıcılar");
          dataGridView1.DataSource= verikumesi.Tables["Kullanıcılar"];
          baglanti.Close();
        }
        public KullanıcıEkle()
        {
            InitializeComponent();
        }

        

        private void KullanıcıEkle_Load(object sender, EventArgs e)
        {
            VeriDoldur();
            listBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txttcno.Text!=""&&txtadi.Text!="")
            {
                if (txtsoyadi.Text!=""&&msktelno.Text!="")
                {
                    if (msktelno.Text != "" && cmbBoxYetki.Text!="")
                    {
                        string tcno=txttcno.Text;
                        komut = new OleDbCommand();
                        baglanti.Open();
                        komut.Connection = baglanti;
                        komut.CommandText = "Select tcno From Kullanıcılar";
                        dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            listBox1.Items.Add( dr["tcno"]);
                        }
                        string d="yanlış";
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (listBox1.Items[i].ToString() == tcno)
                            {
                                MessageBox.Show("Dikkat!","Bu Kimlik Numarası Zaten Var!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                d="dogru";
                                i = listBox1.Items.Count;
                            }
                            
                            
                                
                        }
                        baglanti.Close();
                        if (d=="yanlış")
                        {
                            komut = new OleDbCommand();
                            baglanti.Open();
                            komut.Connection = baglanti;
                            komut.CommandText = "insert into Kullanıcılar (tcno, adı, soyadı,telno, parola,yetki) values (@ptcno, @padı, @psoyadı, @ptelno, @pparola,@pyetki)";

                            komut.Parameters.AddWithValue("@ptcno", txttcno.Text);
                            komut.Parameters.AddWithValue("@padı", txtadi.Text);
                            komut.Parameters.AddWithValue("@psoyadı", txtsoyadi.Text);
                            komut.Parameters.AddWithValue("@ptelno", msktelno.Text);
                            komut.Parameters.AddWithValue("@pparola", txtparola.Text);
                            komut.Parameters.AddWithValue("@pyetki", cmbBoxYetki.Text);

                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            VeriDoldur();
                            txtadi.Clear();
                            txtparola.Clear();
                            txtsoyadi.Clear();
                            txttcno.Clear();
                            msktelno.Clear();
                            
                        }


                        
                        
                    }
                }
            }
            else
            {
                MessageBox.Show(" Lütfen Boş Alanları Doldurunuz!","Dikkat!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txttcno.Text!="")
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete from Kullanıcılar where tcno='" + txttcno.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                verikumesi.Clear();
                VeriDoldur();
            }
            else
            {
                MessageBox.Show(" Lütfen Tc No Alanını Doldurunuz!", "Dikkat!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
