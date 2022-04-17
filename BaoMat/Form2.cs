using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoMat
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Vigenere = new Vigenere();
            Vigenere.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rsa = new Form3();
            rsa.Show();
        }
    }
}
