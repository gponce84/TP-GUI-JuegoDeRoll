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
    public partial class Combate : Form
    {
        Jugador player_Cmbt;
        Enemigo enemy;
        int i = 0;
        int j = 0;
        bool accion = false;
        bool ataque = false;
        bool ataqueEsp = false;
        bool defensa_jug = false;
        bool defensa_ene = false;
        bool critico = false;
        bool turno_player = true;
        int accionar_enemigo;
        Random rmd = new Random();
        Point[] posicion_original = new Point[2];
        PictureBox cls_j;
        EstadisticasCombate ec;

        public Combate(ref Jugador player, PictureBox csl_j)
        {
            Location = new Point(400, 0);
            InitializeComponent();
            player_Cmbt = player;
            enemy = new Enemigo(player_Cmbt.Level);
            calcularProb();
            //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;
            posicion_original[0] = BoxJugador.Location;
            posicion_original[1] = BoxEnemigo.Location;
            ec = new EstadisticasCombate(ref player_Cmbt, ref enemy);
            ec.Location = new Point(this.Size.Width+this.Location.X+20, this.Location.Y);
            ec.actualizar(player_Cmbt.Vida_Real,player_Cmbt.Mana_Real,enemy.Vida_Real,0,0,0);
            this.cls_j = csl_j;  //recibe la casilla cuando se crea el combate

        
            this.AddOwnedForm(ec);
            if (this.OwnedForms != null)
            {
                ec.Show();


            }
            //ec.BringToFront();
        }

        private void Combate_Load(object sender, EventArgs e)
        {
            timerCmbt.Start();


        }

        private void BoxEnemigo_Click(object sender, EventArgs e)
        {

        }

        private void timerCmbt_Tick(object sender, EventArgs e)
        {

            if (!accion)
            {
                BoxJugador.Image = player_Cmbt.animacionNormal();
                i++;
                BoxEnemigo.Image = enemy.animacionNormal();
                j++;
            }
            else
            {
                if (turno_player)
                {
                    if (ataque)
                    {
                        animacionCombate(1);
                        inst_ataque();
                    }
                    else if (ataqueEsp)
                    {
                        animacionCombate(1);
                        inst_ataqueEsp();
                    }
                }
                else
                {
                    if (enemy.Vida_Real > 0 )
                    {

                        
                        switch (accionar_enemigo)
                        {
                            case 1:
                                animacionCombate(2);
                                inst_ataque();

                                if (player_Cmbt.Vida_Real <= 0)
                                {
                                                             

                                    MessageBox.Show("Perdiste Rata inmunda","GAME OVER!!");
                                    Owner.Enabled = true;
                                    Mapa mp = (Mapa)this.Owner;
                                    this.Close();

                                    mp.BringToFront();
                                    Application.Exit();

                                }

                                break;
                            case 2:
                                if (defensa_jug == false)
                                {
                                    defensa_ene = true;
                                    if (Math.Floor(rmd.NextDouble()) <= 50)
                                    {
                                        critico = true;
                                    }
                                    btn_Defender.Enabled = false;
                                    turno_player = true;
                                    accion = false;
                                }
                                else
                                {
                                    accionar_enemigo = rmd.Next(1, 3);
                                    turno_player = false;
                                    accion = true;
                                }

                                break;
                            case 3:
                                if (enemy.Mana_Real >= (int)enemy.Mana_Max * 0.2)
                                {
                                    animacionCombate(2);
                                    inst_ataqueEsp();
                                }
                                else
                                {
                                    accionar_enemigo = rmd.Next(1, 3);
                                    turno_player = false;
                                    accion = true;
                                }
                                break;
                            default:
                                accion = true;
                                break;
                            }
                    }
                    else
                    {
                        accion = false;
                        turno_player = true;
                        //cuando el enemigo muere sube la experiencias
                        MessageBox.Show("Esta vez has Ganado!!",player_Cmbt.Nombre);
                        ec.Close();
                        subirExp();
                        ganaPocion();
                        Owner.Enabled = true;
                        Mapa mp = (Mapa)this.Owner;
                        this.Close();
                        mp.BringToFront();
                        cls_j.BackgroundImage = Properties.Resources.crossed_swords_and_shield;
                        cls_j.BackgroundImageLayout = ImageLayout.Center;

                    }
                }
            }
        }

        private void subirExp()
        {
            player_Cmbt.Experiencia += enemy.Level * 100;
            if (player_Cmbt.Experiencia > player_Cmbt.Level * 1000)
            {
                subirNivel();

            }
        }
        private void subirNivel()
        {
            player_Cmbt.Experiencia = 0;
            player_Cmbt.Level++;
            player_Cmbt.Vida_Max += 10;
            player_Cmbt.Vida_Real = player_Cmbt.Vida_Max;
            player_Cmbt.Mana_Max += 10;
            player_Cmbt.Mana_Real = player_Cmbt.Mana_Max;
            player_Cmbt.Daño_Fisico += 1;
            player_Cmbt.Daño_Magico += 1;
            player_Cmbt.Defensa += 1;
            player_Cmbt.Agilidad += 1;

        }

        private void inst_ataqueEsp()
        {
            if (turno_player)
            {
                if (i >= player_Cmbt.Img_Combate.Count())
                {
                    i = 0;
                    atacarEsp();
                    turno_player = false;
                    ataqueEsp = false;
                    BoxEnemigo.Location = posicion_original[1];
                    timerCmbt.Interval = 200;
                }
            }
            else
            {
                if (j >= enemy.Img_Combate.Count())
                {
                    j = 0;
                    if (i + 1 >= 3)
                    {
                        i = 0;
                    }
                    atacarEsp();
                    accion = false;
                    turno_player = true;
                    BoxJugador.Location = posicion_original[0];
                    timerCmbt.Interval = 200;
                    if (player_Cmbt.Vida_Real <= 0)
                    {
                        timerCmbt.Stop();
                        //this.Owner.Close();
                    }
                }
            }
        }

        private void inst_ataque()
        {
            if (turno_player)
            {
                if (i >= player_Cmbt.Img_Combate.Count())
                {
                    i = 0;
                    atacar();
                    turno_player = false;
                    ataque = false;
                    BoxEnemigo.Location = posicion_original[1];
                    timerCmbt.Interval = 200;
                }
            }
            else
            {
                if (j >= enemy.Img_Combate.Count())
                {
                    j = 0;
                    if (i + 1 >= 3)
                    {
                        i = 0;
                    }
                    atacar();
                    accion = false;
                    turno_player = true;
                    BoxJugador.Location = posicion_original[0];
                    timerCmbt.Interval = 200;
                    if (player_Cmbt.Vida_Real <= 0)
                    {
                        timerCmbt.Stop();
                        //this.Owner.Close();
                    }
                }
            }
        }

        private void atacarEsp()
        {
            int dif = 0;
            if (turno_player)
            {
                if (player_Cmbt.Mana_Real >= (int)player_Cmbt.Mana_Max * 0.2)
                {
                    if (Math.Floor(rmd.NextDouble()) <= player_Cmbt.ProbAcierto) //Tira un numero aleatorio(1 al 100) y si es menos que la probabilidad de acierto se hace el calculo de daño y se le quita vida al enemigo
                    {
                        int valorI1 = enemy.Vida_Real;
                        int valorI2 = player_Cmbt.Mana_Real;

                        dif = ((((int)(player_Cmbt.Daño_Magico * 1.4) + (player_Cmbt.Daño_Fisico / 2)) - enemy.Defensa) / 2) + player_Cmbt.Daño_Magico; //Calcula diferencia entre ataque del jugador y la defensa del enemigo, el resultado se le suma al daño basico 
                        if (defensa_ene)
                        {
                            dif = dif / 2;
                            defensa_ene = false;
                            btn_Defender.Enabled = true;
                        }
                        enemy.Vida_Real -= rmd.Next(dif - 1, dif + 4);
                        player_Cmbt.Mana_Real -= (int)(player_Cmbt.Mana_Max * 0.2);
                        //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;
                        if (player_Cmbt.Mana_Real >= (int)player_Cmbt.Mana_Max * 0.2)
                        {
                            btn_AtEspecial.Enabled = true;
                        }
                        else
                        {
                            btn_AtEspecial.Enabled = false;
                        }

                        //ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, valorI2, valorI1);
                        ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real);
                    }
                }
            }
            else
            {
                if (enemy.Mana_Real >= (int)enemy.Mana_Max * 0.2)
                {
                    int valorI1 = player_Cmbt.Vida_Real;

                    if (Math.Floor(rmd.NextDouble()) <= enemy.ProbAcierto)
                    {
                        dif = dif = ((((int)(enemy.Daño_Magico * 1.4) + (enemy.Daño_Fisico / 2)) - player_Cmbt.Defensa) / 2) + enemy.Daño_Magico; //Calcula diferencia entre ataque del jugador y la defensa del enemigo
                        if (defensa_jug)
                        {
                            dif = dif / 2;
                            defensa_jug = false;
                        }
                        player_Cmbt.Vida_Real -= rmd.Next(dif - 1, dif + 4);
                        enemy.Mana_Real -= (int)(enemy.Mana_Max * 0.2);
                        //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;
                    }
                    //ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, valorI1, player_Cmbt.Mana_Real, enemy.Vida_Real);
                    ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real);
                }
            }
        }

        private void animacionCombate(int a)
        {
            switch (a)
            {
                case 1:
                    timerCmbt.Interval = 100;
                    BoxJugador.Image = player_Cmbt.Img_Combate.ElementAt(i);
                    BoxEnemigo.Image = enemy.animacionNormal();
                    if (i > 5)
                    {
                        BoxEnemigo.Location = posicion_original[1];
                        BoxEnemigo.Location = new Point(rmd.Next(BoxEnemigo.Location.X - 10, BoxEnemigo.Location.X + 10), rmd.Next(BoxEnemigo.Location.Y - 10, BoxEnemigo.Location.Y + 10));
                    }
                    i++;
                    j++;
                    if (j >= 3)
                    {
                        j = 0;
                    }
                    break;
                case 2:
                    timerCmbt.Interval = 100;
                    BoxEnemigo.Image = enemy.Img_Combate.ElementAt(j);
                    BoxJugador.Image = player_Cmbt.animacionNormal();
                    if (j > 5)
                    {
                        BoxJugador.Location = posicion_original[0];
                        BoxJugador.Location = new Point(rmd.Next(BoxJugador.Location.X - 10, BoxJugador.Location.X + 10), rmd.Next(BoxJugador.Location.Y - 10, BoxJugador.Location.Y + 10));
                    }
                    j++;
                    i++;
                    if (i >= 3)
                    {
                        i = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        private void atacar()
        {
            int dif = 0;
            if (turno_player)
            {
                if (Math.Floor(rmd.NextDouble()) <= player_Cmbt.ProbAcierto) //Tira un numero aleatorio(1 al 100) y si es menos que la probabilidad de acierto se hace el calculo de daño y se le quita vida al enemigo
                {
                    int valorI = enemy.Vida_Real;
                    dif = player_Cmbt.Daño_Fisico + (player_Cmbt.Daño_Fisico - enemy.Defensa); //Calcula diferencia entre ataque del jugador y la defensa del enemigo, el resultado se le suma al daño basico 
                    if (defensa_ene)
                    {
                        dif = dif / 2;
                        defensa_ene = false;
                        btn_Defender.Enabled = true;
                    }
                    else if (critico)
                    {
                        dif = dif * 2;
                        critico = false;
                    }
                    enemy.Vida_Real -= rmd.Next(dif - 1, dif + 2);
                    //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;

                   // ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, valorI);
                    ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real);
                }
            }
            else
            {
                if (Math.Floor(rmd.NextDouble()) <= enemy.ProbAcierto)
                {
                    int valorI = player_Cmbt.Vida_Real;
                    dif = enemy.Daño_Fisico + (enemy.Daño_Fisico - player_Cmbt.Defensa); //Calcula diferencia entre ataque del jugador y la defensa del enemigo
                    if (defensa_jug)
                    {
                        dif = dif / 2;
                        defensa_jug = false;
                    }
                    else if (critico)
                    {
                        dif = dif * 2;
                        critico = false;
                    }
                    player_Cmbt.Vida_Real -= rmd.Next(dif - 1, dif + 2);
                    //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;

                    //ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, valorI, player_Cmbt.Mana_Real, enemy.Vida_Real);
                    ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real);
                }
            }
        }

        private void btn_atacar_Click(object sender, EventArgs e)
        {
            i = 3;
            accionar_enemigo = rmd.Next(1, 3);
            ataque = true;
            accion = true;

        }

        private void btn_AtEspecial_Click(object sender, EventArgs e)
        {
            i = 3;
            accionar_enemigo = rmd.Next(1, 3);
            ataqueEsp = true;
            accion = true;
        }

        private void btn_Defender_Click(object sender, EventArgs e)
        {
            defensa_jug = true;
            j = 0;
            if (Math.Floor(rmd.NextDouble()) <= 50)
            {
                critico = true;
            }
            accionar_enemigo = rmd.Next(1, 3);
            turno_player = false;
            accion = true;
        }

        private void btn_Pocion_Click(object sender, EventArgs e)
        {
            j = 0;
            curar();
            //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;
            accionar_enemigo = rmd.Next(1, 3);
            turno_player = false;
            accion = true;
        }

        private void curar()
        {
            if (player_Cmbt.Pociones > 0)
            {
                player_Cmbt.Pociones--;
                int valorI = player_Cmbt.Vida_Real;
                if (player_Cmbt.Vida_Real + (int)(player_Cmbt.Vida_Max * 0.3) > player_Cmbt.Vida_Max)
                {
                    player_Cmbt.Vida_Real = player_Cmbt.Vida_Max;
                }
                else
                {
                    player_Cmbt.Vida_Real += (int)(player_Cmbt.Vida_Max * 0.3);
                }
                if (player_Cmbt.Pociones > 0)
                {
                    btn_Pocion.Enabled = true;
                }
                else
                {
                    btn_Pocion.Enabled = false;
                }
                ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, valorI, player_Cmbt.Mana_Real, enemy.Vida_Real);
            }
            else
            {
                btn_Pocion.Enabled = false;
            }

        }

        private void btn_Escapar_Click(object sender, EventArgs e)
        {
            DialogResult r= MessageBox.Show("Huyes Cobarde?","",MessageBoxButtons.YesNo);

            if(r ==DialogResult.Yes )
            {
                Owner.Enabled = true;
                Mapa mp = (Mapa)this.Owner;
                this.Close();
                mp.BringToFront();
                cls_j.BackgroundImage = Properties.Resources.Xv_2;
                cls_j.BackgroundImageLayout = ImageLayout.Center;
            }               
        }

        private void calcularProb()
        {
            if (player_Cmbt.Agilidad >= enemy.Agilidad)
            {
                player_Cmbt.ProbAcierto = 100;
                enemy.ProbAcierto = 100 - (100 * ((enemy.Agilidad - player_Cmbt.Agilidad) / 30));
            }
            else
            {
                player_Cmbt.ProbAcierto = 100 - (100 * ((enemy.Agilidad - player_Cmbt.Agilidad) / 30));
                enemy.ProbAcierto = 100;
            }
        }

        private void btn_Mana_Click(object sender, EventArgs e)
        {
            j = 0;
            recuperarMana();
            //Text = "Enemigo: " + enemy.Vida_Real + " Mana: " + enemy.Mana_Real + " Jugador: " + player_Cmbt.Vida_Real + " Mana: " + player_Cmbt.Mana_Real;
            accionar_enemigo = rmd.Next(1, 3);
            turno_player = false;
            accion = true;
        }

        private void recuperarMana()
        {
            if (player_Cmbt.PocionesMana > 0)
            {
                player_Cmbt.PocionesMana--;
                int valorI = player_Cmbt.Mana_Real;
                if (player_Cmbt.Mana_Real + (int)(player_Cmbt.Mana_Max * 0.3) > player_Cmbt.Mana_Max)
                {
                    player_Cmbt.Mana_Real = player_Cmbt.Mana_Max;
                }
                else
                {
                    player_Cmbt.Mana_Real += (int)(player_Cmbt.Mana_Max * 0.3);
                }
                ec.actualizar(player_Cmbt.Vida_Real, player_Cmbt.Mana_Real, enemy.Vida_Real, player_Cmbt.Vida_Real, valorI, enemy.Vida_Real);
                if (player_Cmbt.PocionesMana > 0)
                {
                    btn_Mana.Enabled = true;
                }
                else
                {
                    btn_Mana.Enabled = false;
                }
            }
            else
            {
                btn_Mana.Enabled = false;
            };

        }

        private void ganaPocion()
        {
            if(Math.Floor(rmd.NextDouble())>50)
            {
                int a = rmd.Next(1, 2);
                switch (a)
                {
                    case 1:
                        player_Cmbt.Pociones++;
                        break;
                    case 2:
                        player_Cmbt.PocionesMana++;
                        break;
                }
            }
        }

    }
}
