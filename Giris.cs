using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=KullaniciKayit;Trusted_Connection=True;");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            if (comboBox1.Text == "Kullanıcı")
            {
                com.CommandText = "Select * from kullanici where kullaniciAdi = '" + textBox1.Text + "' And sifre = '" +
                    textBox2.Text + "'";
            }
            else if (comboBox1.Text == "Admin")
            {
                com.CommandText = "Select * from adminler where kullaniciAdi = '" + textBox1.Text + "' And sifre = '" +
                   textBox2.Text + "'";
            }

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Bilgileri Hatalı.Lütfen Kontrol Edin.");
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.Show();
            this.Hide();
        }
    }
}
