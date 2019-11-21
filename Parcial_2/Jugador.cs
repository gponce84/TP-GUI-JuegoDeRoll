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
    public class Jugador
    {
        private List<Image> img_Mapa = new List<Image>();
        private List<Image> img_Combate = new List<Image>();
        private int vida_Max;
        private int vida_Real;
        private int mana_Max;
        private int mana_Real;
        private int daño_Fisico;
        private int daño_Magico;
        private int defensa;
        private int agilidad;
        private int level = 1;
        private int pociones = 3;
        private int pocionesMana = 3;
        private double probAcierto;
        private int exp = 100;
        private int exp_Actual = 0;
        private int ctdor = 0;
        private String nombre;

        public List<Image> Img_Mapa
        {
            get
            {
                return img_Mapa;
            }

            set
            {
                img_Mapa = value;
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

        public int Pociones
        {
            get
            {
                return pociones;
            }

            set
            {
                pociones = value;
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
        public int Experiencia
        {
            get
            {
                return exp_Actual;
            }

            set
            {
                exp_Actual = value;
            }
        }
        public int PocionesMana
        {
            get
            {
                return pocionesMana;
            }

            set
            {
                pocionesMana = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public Image animacionNormal()
        {
            Image img = Img_Combate.ElementAt(ctdor);
            ctdor++;
            if (ctdor >= 3)
            {
                ctdor = 0;

            }
            return img;
        }

        public Jugador(int clase)
        {
            switch (clase)
            {
                case 1:
                    vida_Max = 100;
                    vida_Real = vida_Max;
                    mana_Max = 80;
                    mana_Real = mana_Max;
                    daño_Fisico = 17;
                    daño_Magico = 15;
                    defensa = 11;
                    agilidad = 15;
                    img_Mapa.Add(Properties.Resources.assasin_map1);
                    img_Mapa.Add(Properties.Resources.assasin_map2);
                    img_Mapa.Add(Properties.Resources.assasin_map3);
                    img_Mapa.Add(Properties.Resources.assasin_map4);
                    Img_Combate.Add(Properties.Resources.assasin_Idle1);
                    Img_Combate.Add(Properties.Resources.assasin_Idle2);
                    Img_Combate.Add(Properties.Resources.assasin_Idle3);
                    Img_Combate.Add(Properties.Resources.assasin_ataque1);
                    Img_Combate.Add(Properties.Resources.assasin_ataque2);
                    Img_Combate.Add(Properties.Resources.assasin_ataque3);
                    Img_Combate.Add(Properties.Resources.assasin_ataque4);
                    Img_Combate.Add(Properties.Resources.assasin_ataque5);
                    Img_Combate.Add(Properties.Resources.assasin_ataque6);
                    break;
                case 2:
                    vida_Max = 120;
                    vida_Real = vida_Max;
                    mana_Max = 50;
                    mana_Real = mana_Max;
                    daño_Fisico = 19;
                    daño_Magico = 9;
                    defensa = 14;
                    agilidad = 8;
                    img_Mapa.Add(Properties.Resources.warrior_map1);
                    img_Mapa.Add(Properties.Resources.warrior_map2);
                    img_Mapa.Add(Properties.Resources.warrior_map3);
                    img_Mapa.Add(Properties.Resources.warrior_map4);
                    Img_Combate.Add(Properties.Resources.warrior_Idle1);
                    Img_Combate.Add(Properties.Resources.warrior_Idle2);
                    Img_Combate.Add(Properties.Resources.warrior_Idle3);
                    Img_Combate.Add(Properties.Resources.warrior_ataque1);
                    Img_Combate.Add(Properties.Resources.warrior_ataque2);
                    Img_Combate.Add(Properties.Resources.warrior_ataque3);
                    Img_Combate.Add(Properties.Resources.warrior_ataque4);
                    Img_Combate.Add(Properties.Resources.warrior_ataque5);
                    Img_Combate.Add(Properties.Resources.warrior_ataque6);
                    break;
                case 3:
                    vida_Max = 80;
                    vida_Real = vida_Max;
                    mana_Max = 120;
                    mana_Real = mana_Max;
                    daño_Fisico = 8;
                    daño_Magico = 20;
                    defensa = 12;
                    agilidad = 11;
                    img_Mapa.Add(Properties.Resources.wizard_map1);
                    img_Mapa.Add(Properties.Resources.wizard_map2);
                    img_Mapa.Add(Properties.Resources.wizard_map3);
                    img_Mapa.Add(Properties.Resources.wizard_map4);
                    Img_Combate.Add(Properties.Resources.wizard_Idle1);
                    Img_Combate.Add(Properties.Resources.wizard_Idle2);
                    Img_Combate.Add(Properties.Resources.wizard_Idle3);
                    Img_Combate.Add(Properties.Resources.wizard_ataque1);
                    Img_Combate.Add(Properties.Resources.wizard_ataque2);
                    Img_Combate.Add(Properties.Resources.wizard_ataque3);
                    break;
            }
        }
    }
}
