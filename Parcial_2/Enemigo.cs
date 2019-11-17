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
    public class Enemigo
    {
        private List<Image> img_Combate = new List<Image>();
        private int vida_Max;
        private int vida_Real;
        private int mana_Max;
        private int mana_Real;
        private int daño_Fisico;
        private int daño_Magico;
        private int defensa;
        private int agilidad;
        private int level;
        private double probAcierto;
        private int ctdor = 0;

        public Enemigo(int playerLevel)
        {
            Random rmd = new Random();
            int tipo_Enemigo = rmd.Next(1, 15);

            switch (tipo_Enemigo)
            {

                case 1:
                case 4:
                case 7:
                case 10:
                case 13:
                    level = 1;
                    vida_Max = 105;
                    vida_Real = vida_Max;
                    mana_Max = 80;
                    mana_Real = mana_Max;
                    daño_Fisico = 14;
                    daño_Magico = 14;
                    defensa = 10;
                    agilidad = 13;
                    img_Combate.Add(Properties.Resources.Enemy1_Idle1);
                    img_Combate.Add(Properties.Resources.Enemy1_Idle2);
                    img_Combate.Add(Properties.Resources.Enemy1_Idle3);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque1);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque2);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque3);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque4);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque5);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque6);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque7);
                    img_Combate.Add(Properties.Resources.Enemy1_ataque8);

                    if (playerLevel > 1)
                    {
                        level = rmd.Next(playerLevel - 1, playerLevel + 2);
                        for (int i = 1; i <= level; i++)
                        {
                            vida_Max += rmd.Next(3, 5);
                            vida_Real = vida_Max;
                            mana_Max += rmd.Next(2, 4);
                            mana_Real = mana_Max;
                            daño_Fisico += rmd.Next(1, 3);
                            daño_Magico += rmd.Next(1, 3);
                            agilidad += rmd.Next(1, 3);
                        }
                    }
                    break;
                case 2:
                case 5:
                case 8:
                case 11:
                case 14:
                    level = 1;
                    vida_Max = 110;
                    vida_Real = vida_Max;
                    mana_Max = 70;
                    mana_Real = mana_Max;
                    daño_Fisico = 15;
                    daño_Magico = 11;
                    defensa = 9;
                    agilidad = 6;
                    img_Combate.Add(Properties.Resources.Enemy2_Idle1);
                    img_Combate.Add(Properties.Resources.Enemy2_Idle2);
                    img_Combate.Add(Properties.Resources.Enemy2_Idle3);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque1);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque2);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque3);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque4);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque5);
                    img_Combate.Add(Properties.Resources.Enemy2_ataque6);

                    if (playerLevel > 1)
                    {
                        level = rmd.Next(playerLevel - 1, playerLevel + 2);
                        for (int i = 1; i <= level; i++)
                        {
                            vida_Max += rmd.Next(8, 15);
                            vida_Real = vida_Max;
                            mana_Max += rmd.Next(1, 3);
                            mana_Real = mana_Max;
                            daño_Fisico += rmd.Next(1, 2);
                            daño_Magico += rmd.Next(0, 1);
                            agilidad += rmd.Next(0, 1);
                        }
                    }
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                case 15:
                    level = 1;
                    vida_Max = 95;
                    vida_Real = vida_Max;
                    mana_Max = 110;
                    mana_Real = mana_Max;
                    daño_Fisico = 8;
                    daño_Magico = 17;
                    defensa = 10;
                    agilidad = 9;
                    img_Combate.Add(Properties.Resources.Enemy3_Idle1);
                    img_Combate.Add(Properties.Resources.Enemy3_Idle2);
                    img_Combate.Add(Properties.Resources.Enemy3_Idle3);
                    img_Combate.Add(Properties.Resources.Enemy3_ataque1);
                    img_Combate.Add(Properties.Resources.Enemy3_ataque2);
                    img_Combate.Add(Properties.Resources.Enemy3_ataque3);

                    if (playerLevel > 1)
                    {
                        level = rmd.Next(playerLevel - 1, playerLevel + 2);
                        for (int i = 1; i <= level; i++)
                        {
                            vida_Max += rmd.Next(7, 10);
                            vida_Real = vida_Max;
                            mana_Max += rmd.Next(9, 14);
                            mana_Real = mana_Max;
                            daño_Fisico += rmd.Next(0, 1);
                            daño_Magico += rmd.Next(2, 4);
                            defensa += rmd.Next(1, 2);
                            agilidad += rmd.Next(1, 2);
                        }
                    }
                    break;

            }
        }
        public int Vida_Max
        {
            get
            {
                return vida_Max;
            }

            set
            {
                vida_Max = value;
            }
        }

        public int Vida_Real
        {
            get
            {
                return vida_Real;
            }

            set
            {
                vida_Real = value;
            }
        }

        public int Mana_Max
        {
            get
            {
                return mana_Max;
            }

            set
            {
                mana_Max = value;
            }
        }

        public int Mana_Real
        {
            get
            {
                return mana_Real;
            }

            set
            {
                mana_Real = value;
            }
        }

        public int Daño_Fisico
        {
            get
            {
                return daño_Fisico;
            }

            set
            {
                daño_Fisico = value;
            }
        }

        public int Daño_Magico
        {
            get
            {
                return daño_Magico;
            }

            set
            {
                daño_Magico = value;
            }
        }

        public int Defensa
        {
            get
            {
                return defensa;
            }

            set
            {
                defensa = value;
            }
        }

        public int Agilidad
        {
            get
            {
                return agilidad;
            }

            set
            {
                agilidad = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public List<Image> Img_Combate
        {
            get
            {
                return img_Combate;
            }

            set
            {
                img_Combate = value;
            }
        }

        public double ProbAcierto
        {
            get
            {
                return probAcierto;
            }

            set
            {
                probAcierto = value;
            }
        }

        public int Ctdor
        {
            get
            {
                return ctdor;
            }

            set
            {
                ctdor = value;
            }
        }

        public Image animacionNormal()
        {
            Image img = Img_Combate.ElementAt(ctdor);
            if (Vida_Real > 0)
            {
                ctdor++;
                if (ctdor >= 3)
                {
                    ctdor = 0;
                }
                return img;
            }
            else
            {
                return img = null;
            }
        }

        public Image secuenciaCmbt()
        {
            Image img = Img_Combate.ElementAt(ctdor);
            if (Vida_Real > 0)
            {
                ctdor++;
                return img;
            }
            else
            {
                return img = null;
            }
        }
    }
}
