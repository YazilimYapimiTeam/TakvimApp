using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Hatirlatici : Form
    {
        public Hatirlatici()
        {
            InitializeComponent();
        }
        static string conString = "Server=localhost\\SQLEXPRESS;Database=KullaniciKayit;Trusted_Connection=True;";
        SqlConnection baglanti = new SqlConnection(conString);
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            dateTimePicker1.CustomFormat = "MMMM dd, yyyy  dddd - HH:mm:ss";
            HatirlaticiGetir();

        }

        private void HatirlaticiGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From hatirlatici", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "hatirlatici");
            dataGridView1.DataSource = ds.Tables["hatirlatici"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int sonuc = DateTime.Compare(dateTimePicker1.Value, DateTime.Now);
                if (sonuc >= 0)
                {
                if (textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    string no = textBox1.Text.Trim();
                    string tanim = textBox2.Text.Trim();
                    string tip = textBox3.Text.Trim();
                    string aciklama = textBox4.Text.Trim();
                    DateTime tarihIslem = dateTimePicker2.Value;
                    dateTimePicker2.Value = DateTime.Now;
                    DateTime tarihOlay = dateTimePicker1.Value;
                    baglanti.Open();
                    string kayit = "insert into hatirlatici(islemZaman,olayZaman,olayTanim,olayTip,olayAciklama) values (@islemZaman,@olayZaman,@olayTanim,@olayTip,@olayAciklama)";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@hatirlaticiId", textBox1.Text);
                    komut.Parameters.AddWithValue("@islemZaman", dateTimePicker2.Value);
                    komut.Parameters.AddWithValue("@olayZaman", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@olayTanim", textBox4.Text);
                    komut.Parameters.AddWithValue("@olayTip", textBox3.Text);
                    komut.Parameters.AddWithValue("@olayAciklama", textBox2.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hatırlatma başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HatirlaticiGetir();
                    string sorgu = "Select olayZaman from hatirlatici";
                    SqlCommand komut1 = new SqlCommand(sorgu, baglanti);
                    
                   
                }
                    else
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ileride bir tarih seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string kayit = "delete from hatirlatici where hatirlaticiId = @hatirlaticiId";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@hatirlaticiId", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            HatirlaticiGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kayit = "Update hatirlatici Set islemZaman = @islemZaman,olayZaman = @olayZaman,olayTanim = @olayTanim,olayTip = @olayTip,olayAciklama = @olayAciklama Where hatirlaticiId=@hatirlaticiId";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@hatirlaticiId", textBox1.Text);
            komut.Parameters.AddWithValue("@islemZaman", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@olayZaman", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@olayTanim", textBox4.Text);
            komut.Parameters.AddWithValue("@olayTip", textBox3.Text);
            komut.Parameters.AddWithValue("@olayAciklama", textBox2.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            HatirlaticiGetir();
            HatirlaticiGetir();
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show(this);
            this.Hide();
        }
    }

        
    }

