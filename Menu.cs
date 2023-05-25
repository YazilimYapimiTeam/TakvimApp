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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hatirlatici hatirlatici = new Hatirlatici();
            hatirlatici.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Takvim takvim = new Takvim();
            takvim.Show();
            this.Hide();
        }
    }
}
