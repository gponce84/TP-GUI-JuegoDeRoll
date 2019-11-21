using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Personajes : Form
    {
        int i = 0;
        int img;
        string nombre;
        public Personajes(string nom)
        {
            InitializeComponent();
            nombre = nom;
        }
        private void Personajes_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mapa frm = new Mapa(img, nombre);
            frm.Show();
        }

        private void radioButton1_Validated(object sender, EventArgs e)
        {
            img = 1;
        }

        private void radioButton2_Validated(object sender, EventArgs e)
        {
            img = 2;
        }

        private void radioButton3_Validated(object sender, EventArgs e)
        {
            img = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                radioButton1.Image = Properties.Resources.assasin_img;
                radioButton2.Image = Properties.Resources.warrior_img2;
                radioButton3.Image = Properties.Resources.wizard_img;
                i++;
            }
            else
            {
                radioButton1.Image = Properties.Resources.assasin_img2;
                radioButton2.Image = Properties.Resources.warrior_img;
                radioButton3.Image = Properties.Resources.wizard_img2;
                i = 0;
            }

        }
    }
}
