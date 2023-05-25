using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }
        static string conString = "Server=localhost\\SQLEXPRESS;Database=KullaniciKayit;Trusted_Connection=True;";
        SqlConnection baglanti = new SqlConnection(conString);
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris form4 = new Giris();
            form4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                if  (comboBox1.Text == "Kullanıcı")
                {
                    string kayit = "insert into kullanici(isim,soyisim,kullaniciAdi,sifre,tcNo,tel,mail,adres) values (@isim,@soyisim,@kullaniciAdi,@sifre,@tcNo,@tel,@mail,@adres)";
                
                    SqlCommand komut = new SqlCommand(kayit, baglanti);

                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@soyisim", textBox2.Text);
                    komut.Parameters.AddWithValue("@kullaniciAdi", textBox3.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                    komut.Parameters.AddWithValue("@tcNo", textBox5.Text);
                    komut.Parameters.AddWithValue("@tel", textBox6.Text);
                    komut.Parameters.AddWithValue("@mail", textBox7.Text);
                    komut.Parameters.AddWithValue("@adres", textBox8.Text);

                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    MessageBox.Show("Kullanıcı Kayıt İşlemi Gerçekleşti.");
                }

                else if (comboBox1.Text == "Admin")
                {
                    string kayit = "insert into adminler(isim,soyisim,kullaniciAdi,sifre,tcNo,tel,mail,adres) values (@isim,@soyisim,@kullaniciAdi,@sifre,@tcNo,@tel,@mail,@adres)";

                    SqlCommand komut = new SqlCommand(kayit, baglanti);

                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@soyisim", textBox2.Text);
                    komut.Parameters.AddWithValue("@kullaniciAdi", textBox3.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                    komut.Parameters.AddWithValue("@tcNo", textBox5.Text);
                    komut.Parameters.AddWithValue("@tel", textBox6.Text);
                    komut.Parameters.AddWithValue("@mail", textBox7.Text);
                    komut.Parameters.AddWithValue("@adres", textBox8.Text);

                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    MessageBox.Show("Admin Kayıt İşlemi Gerçekleşti.");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
