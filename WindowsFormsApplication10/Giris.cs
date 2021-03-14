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
    

    public partial class Giris : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=SiparisSis.accdb");
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        OleDbCommand komut = new OleDbCommand();
        DataSet verikumesi = new DataSet();
        OleDbDataReader dr;
        public Giris()
        {
            InitializeComponent();
        }
        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            string yetki;
            if (radioButton1.Checked==true)
            {
                yetki = "Yönetici";
            }
            else
            {
                yetki = "Garson";
            }
            baglanti.Open();
            string ad = textBox1.Text;
            string parola = maskedTextBox1.Text;
            komut.Connection = baglanti;
            komut.CommandText = "Select * From Kullanıcılar where adı='"+textBox1.Text+"'AND parola='"+maskedTextBox1.Text+"'AND yetki='"+yetki+"'";
            dr = komut.ExecuteReader();
            

            if (hak != 1)
            {
                if (dr.Read())
                {
                if (yetki == "Yönetici")
                    {
                        Yonetici frm = new Yonetici();
                        frm.Show();
                    }
                    else
                    {
                        Kullanıcı form = new Kullanıcı();
                        form.Show();
                    }
                }
                else
                {
                    hak--;
                    label5.Text = Convert.ToString(hak);
                }
            }
            else
            {
                hak--;
                label5.Text = Convert.ToString(hak);
                label5.BackColor = Color.Red;
                button1.Enabled = false;

            }
            baglanti.Close();
        }

        private void Giris_Shown(object sender, EventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
