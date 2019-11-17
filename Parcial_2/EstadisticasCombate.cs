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
    public partial class EstadisticasCombate : Form
    {
        Timer t = new Timer();
        int valorFinal = 5;

        Jugador jugador;
        Enemigo enemigo;

        int valorFinal2 = 5;
        int valorFinal3 = 5;

        bool detenerse1;
        bool detenerse2;
        bool detenerse3;


        int decremento1;
        int decremento2;
        int decremento3;

        //pb = ProgressBar
        double pbUnit, pbUnit2, pbUnit3;
        int pbWIDTH, pbHEIGHT, pbComplete;
        int pbComplete2, pbComplete3;

        Bitmap bmp, bmp2, bmp3;
        Graphics g;

        public EstadisticasCombate(ref Jugador player, ref Enemigo enemy)
        {
            jugador = player;
            enemigo = enemy;

            InitializeComponent();
            
        }
        public void actualizar(int valf, int valf2, int valf3, int vali, int vali2, int vali3)
        {

            detenerse1 = detenerse2 = detenerse3 = false;

            valorFinal = valf;
            valorFinal2 = valf2;
            valorFinal3 = valf3;

            decremento1 = (valorFinal - vali) / 20;
            decremento2 = (valorFinal2 - vali2) / 20;
            decremento3 = (valorFinal3 - vali3) / 20;

            pbComplete = vali;
            pbComplete2 = vali2;
            pbComplete3 = vali3;

            t.Interval = 5;
            t.Start();
        }


        private void EstadisticasCombate_Load(object sender, EventArgs e)
        {

            label6.Text = "Exp: " + jugador.Experiencia;
            //get picboxPB dimension
            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;

            pbUnit = pbWIDTH / (double)jugador.Vida_Max;
            pbUnit2 = pbWIDTH / (double)jugador.Mana_Max;
            pbUnit3 = pbWIDTH / (double)enemigo.Vida_Max;


            //create bitmap
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);
            bmp2 = new Bitmap(pbWIDTH, pbHEIGHT);
            bmp3 = new Bitmap(pbWIDTH, pbHEIGHT);


            actualizar(jugador.Vida_Real, jugador.Mana_Real, enemigo.Vida_Real, 0, 0, 0);

            //timer
            //in millisecond
            t.Tick += new EventHandler(this.t_Tick);

            //this.BringToFront();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            //graphics
            g = Graphics.FromImage(bmp);


            g.Clear(Color.LightSalmon);


            g.FillRectangle(Brushes.Red, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));




            g.DrawString(pbComplete + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));


            picboxPB.Image = bmp;


            pbComplete += decremento1;

            //pbComplete++;
            if ((decremento1 <= 0 && pbComplete <= valorFinal) || (decremento1 > 0 && pbComplete >= valorFinal))
            //if (pbComplete <= valorFinal)
            {

                pbComplete = valorFinal;
                g.Clear(Color.LightSalmon);
                g.FillRectangle(Brushes.Red, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));
                g.DrawString(pbComplete + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));
                //g.Dispose();

                detenerse1 = true;


            }


            //g.Dispose();
            //graphics
            g = Graphics.FromImage(bmp2);


            g.Clear(Color.LightSkyBlue);


            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(0, 0, (int)(pbComplete2 * pbUnit2), pbHEIGHT));




            g.DrawString(pbComplete2 + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));


            pictureBox1.Image = bmp2;


            pbComplete2 += decremento2;
            //pbComplete++;

            if ((decremento2 <= 0 && pbComplete2 <= valorFinal2) || (decremento2 > 0 && pbComplete2 >= valorFinal2))
            //if (pbComplete2 <= valorFinal2)
            {

                pbComplete2 = valorFinal2;
                g.Clear(Color.LightSkyBlue);
                g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(0, 0, (int)(pbComplete2 * pbUnit2), pbHEIGHT));
                g.DrawString(pbComplete2 + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));
                // g.Dispose();

                detenerse2 = true;
                //t.Stop();


            }


            // g.Dispose();
            //graphics
            g = Graphics.FromImage(bmp3);


            g.Clear(Color.LightGoldenrodYellow);


            g.FillRectangle(Brushes.YellowGreen, new Rectangle(0, 0, (int)(pbComplete3 * pbUnit3), pbHEIGHT));




            g.DrawString(pbComplete3 + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));


            pictureBox2.Image = bmp3;


            pbComplete3 += decremento3;
            //pbComplete++;

            if ((decremento3 <= 0 && pbComplete3 <= valorFinal3) || (decremento3 > 0 && pbComplete3 >= valorFinal3))
            //if (pbComplete3 <= valorFinal3)
            {

                pbComplete3 = valorFinal3;
                g.Clear(Color.LightGoldenrodYellow);

                g.FillRectangle(Brushes.YellowGreen, new Rectangle(0, 0, (int)(pbComplete3 * pbUnit3), pbHEIGHT));
                g.DrawString(pbComplete3 + "", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));
                // g.Dispose();

                detenerse3 = true;
                //t.Stop();
            }




            if (detenerse1 && detenerse2 && detenerse3)
            {
                detenerse1 = detenerse2 = detenerse3 = false;
                t.Stop();
            }


        }
    }
}
