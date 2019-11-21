using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SQLite;

namespace Parcial_2
{
    public partial class Mapa : Form
    {
        int anchobtn = 80;
        int altobtn = 60;
        Jugador player;
        Image piso = Properties.Resources.piso2;
        Label label = new Label();
        Random rnd = new Random();
        Casilla csl_j = new Casilla();//
        List<Casilla> listCasillas = new List<Casilla>();
        int cantCombates = 0;
        int numeroMapa;

        public Mapa(int clase, string nombre, int mapa, int exp)
        {
            InitializeComponent();
            label.Text = "Nombre:  " + nombre;
            player = new Jugador(clase, exp);
            player.Nombre = nombre;
            numeroMapa = mapa;
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            GenerateMap();
            switch (numeroMapa)
            {
                case 1:
                    BackgroundImage = Properties.Resources.Mapa1;
                    BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 2:
                    BackgroundImage = Properties.Resources.Snowy;
                    BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 3:
                    BackgroundImage = Properties.Resources.dungeon;
                    BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    DialogResult r = MessageBox.Show("HAS GANANADO EL JUEGO", "", MessageBoxButtons.OK);

                    if (r == DialogResult.OK)
                    {
                        Application.Exit();

                    }
                    break;


            }



            //BackgroundImage = Properties.Resources.Mapa1;
            //BackgroundImage = Properties.Resources.Snowy;
            //BackgroundImageLayout = ImageLayout.Tile;
            label.TextAlign = ContentAlignment.BottomLeft;
            label.Font = new Font("Arial Black", 12);
            label.Location = new Point(0, altobtn * 10);
            label.Size = new Size(this.ClientSize.Width, 500);
            label.Dock = DockStyle.Bottom;
        }

        private void GenerateMap()
        {
            int casilla_spawn = rnd.Next(0, 99);
            int j = 0;
            for (int i = 0; i < 100; i++)
            {
                Casilla csl = new Casilla(i);
                if (i == casilla_spawn)
                {
                    csl.Image = player.Img_Mapa.ElementAt(0);
                    //csl.BackgroundImage = Properties.Resources.movimiento2;
                    csl.BackgroundImageLayout = ImageLayout.Stretch;

                }
                listCasillas.Add(csl);
                this.Controls.Add(csl);
                this.Controls.Add(label);
            }
        }

        public void pintarPuertaSalida()
        {
            int salida = rnd.Next(0, 99);

            Casilla puerta = listCasillas[salida];
            puerta.BackgroundImage = Properties.Resources.gate;
            puerta.BackgroundImageLayout = ImageLayout.Zoom;
            puerta.Tag = "puerta";


        }

        public void entroPuerta()
        {
            
            this.Hide();
            
            Mapa frm = new Mapa(player.clase, player.Nombre, numeroMapa+1, player.Experiencia);
            frm.Show();
        }

        private void Mapa_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Mapa_KeyUp(object sender, KeyEventArgs e)
        {
           


            foreach (Control csl in Controls)
            {
                Casilla st= null;

                if (typeof(Casilla) == csl.GetType() && player.Img_Mapa.Contains(((Casilla)csl).Image))
                {
                    csl_j = (Casilla)csl;// Con esto sabemos en que control esta el personaje
                }


                if(typeof(Casilla) == csl.GetType())
                {
                     st = (Casilla)csl;
                }
          


                if(st != null && st.Tag != null && st.Tag.Equals("puerta") )
                {
                    if (st.Location.X == csl_j.Location.X - anchobtn &&
                       st.Location.Y == csl_j.Location.Y)
                    {
                        entroPuerta();
                         //MessageBox.Show("puerta salida");
                    }
                }

            }
            if (e.KeyCode == Keys.Left && csl_j.Location.X != 0)
            {
                foreach (Control csl in Controls)
                {
                    if (csl.Location.X == csl_j.Location.X - anchobtn &&
                        csl.Location.Y == csl_j.Location.Y)
                    {

                        if (((Casilla)csl).Tag != null && ((Casilla)csl).Tag.Equals("puerta"))
                        {
                            entroPuerta();
                            //MessageBox.Show("puerta salida");
                            // Application.Exit();

                        }
                        else
                        {

                            ((Casilla)csl).Image = player.Img_Mapa.ElementAt(2);
                            //csl.BackgroundImage = csl_j.BackgroundImage;
                            if (csl_j.BackgroundImage == null)
                            {
                                csl_j.Image = Properties.Resources.movimientoLeft;
                            }
                            else
                            {
                                csl_j.Image = null;
                            }

                            //csl.BackgroundImageLayout = ImageLayout.Stretch;
                            Pelea((Casilla)csl);
                        }


                    }
                }
                
            }
            else if (e.KeyCode == Keys.Right && csl_j.Location.X < anchobtn * 9)
            {
                foreach (Control csl in Controls)
                {
                    if (csl.Location.X == csl_j.Location.X + anchobtn &&
                        csl.Location.Y == csl_j.Location.Y)
                    {
                        if (((Casilla)csl).Tag != null && ((Casilla)csl).Tag.Equals("puerta"))
                        {
                          
                            entroPuerta();
                        }
                        else
                        {

                            ((Casilla)csl).Image = player.Img_Mapa.ElementAt(1);

                            if (csl_j.BackgroundImage == null)
                            {
                                csl_j.Image = Properties.Resources.movimientoRight;
                            }
                            else
                            {
                                csl_j.Image = null;
                            }

                            Pelea((Casilla)csl);
                        }


                    }
                }

            }
            else if (e.KeyCode == Keys.Up && csl_j.Location.Y != 0)
            {
                foreach (Control csl in Controls)
                {
                    if (csl.Location.X == csl_j.Location.X &&
                        csl.Location.Y == csl_j.Location.Y - altobtn)
                    {

                        if (((Casilla)csl).Tag != null && ((Casilla)csl).Tag.Equals("puerta"))
                        {
                            entroPuerta();
                        }
                        else
                        {
                            ((Casilla)csl).Image = player.Img_Mapa.ElementAt(3);

                            if (csl_j.BackgroundImage == null)
                            {
                                csl_j.Image = Properties.Resources.movimientoUp;
                            }
                            else
                            {
                                csl_j.Image = null;
                            }
                            Pelea((Casilla)csl);
                        }
                    }
                }
               
            }
            else if (e.KeyCode == Keys.Down && csl_j.Location.Y < altobtn * 9)
            {
                foreach (Control csl in Controls)
                {
                    if (csl.Location.X == csl_j.Location.X &&
                        csl.Location.Y == csl_j.Location.Y + altobtn)
                    {

                        if (((Casilla)csl).Tag != null && ((Casilla)csl).Tag.Equals("puerta"))
                        {

                            //MessageBox.Show("puerta salida");
                            //Application.Exit();
                            entroPuerta();

                        }
                        else
                        {
                            ((Casilla)csl).Image = player.Img_Mapa.ElementAt(0);
                            //csl.BackgroundImage = csl_j.BackgroundImage;
                            if (csl_j.BackgroundImage == null)
                            {
                                csl_j.Image = Properties.Resources.movimientoDown;
                            }
                            else
                            {
                                csl_j.Image = null;

                            }

                            //csl.BackgroundImageLayout = ImageLayout.Stretch;
                            Pelea((Casilla)csl);
                        }
                    }
                }
                //Pelea();
            }

        }

        void Pelea(Casilla csl)
        {
            

            this.Enabled = false;
            int r = rnd.Next(1, 100);
            if (r <= 20)
            {
                Combate cmbt = new Combate(ref player, csl);
                
                //EstadisticasCombate cmbt = new EstadisticasCombate(ref player);
                this.AddOwnedForm(cmbt);
                if (this.OwnedForms != null)
                {
                    cmbt.Show();
                    cantCombates++;
                    if(cantCombates == 5)
                    {
                        pintarPuertaSalida();

                    }
                }
                    
            }
        }
   
      }

    }//



