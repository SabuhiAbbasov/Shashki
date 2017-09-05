using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shashki
{
    public partial class Form1 : Form
    {

        int count = 0;
        bool movExtra = false;
        PictureBox sectionodo = null;

        List<PictureBox> Azuls = new List<PictureBox>();
        List<PictureBox> Ajaxs = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            redLists();
        }

        private void redLists()
        {
            Azuls.Add(Azul1);
            Azuls.Add(Azul2);
            Azuls.Add(Azul3);
            Azuls.Add(Azul4);
            Azuls.Add(Azul5);
            Azuls.Add(Azul6);
            Azuls.Add(Azul7);
            Azuls.Add(Azul8);
            Azuls.Add(Azul9);
            Azuls.Add(Azul10);
            Azuls.Add(Azul11);
            Azuls.Add(Azul12);


            Ajaxs.Add(Ajax1);
            Ajaxs.Add(Ajax2);
            Ajaxs.Add(Ajax3);
            Ajaxs.Add(Ajax4);
            Ajaxs.Add(Ajax5);
            Ajaxs.Add(Ajax6);
            Ajaxs.Add(Ajax7);
            Ajaxs.Add(Ajax8);
            Ajaxs.Add(Ajax9);
            Ajaxs.Add(Ajax10);
            Ajaxs.Add(Ajax11);
            Ajaxs.Add(Ajax12);
        }

        public void section(Object obj)
        {
            try { sectionodo.BackColor = Color.Black; }
            catch { }
            PictureBox ficha = (PictureBox)obj;
            sectionodo = ficha;
            sectionodo.BackColor = Color.Lime;
        }



        private void CuodroClick(object sender, MouseEventArgs e)
        {
            moov((PictureBox)sender);
        }

        private void moov(PictureBox Cuodro)
        {
            if (sectionodo != null)
            {
                string color = sectionodo.Name.ToString().Substring(0, 4);

                if (validection(sectionodo,Cuodro,color))
                {
                    Point anterior = sectionodo.Location;
                    sectionodo.Location = Cuodro.Location;
                    int avance = anterior.Y - Cuodro.Location.Y;

                    if (true)
                    {
                        ifQueen(color);
                        count++;
                        sectionodo.BackColor = Color.Black;
                        sectionodo = null;
                        movExtra = false;
                    }
                    else
                    {
                        movExtra = true;
                    }
                }
            }
        }

        private bool moovExtras(string color)
        {
            List<PictureBox> bandoContrario = color == "red" ? Azuls : Ajaxs;
            List<Point> posiciones = new List<Point>();
            int sigPosicion = color == "red" ? -100 : 100;

            posiciones.Add(new Point(sectionodo.Location.X + 100, sectionodo.Location.Y + sigPosicion));
            posiciones.Add(new Point(sectionodo.Location.X - 100, sectionodo.Location.Y + sigPosicion));

            if(sectionodo.Tag == "queen")
            {
                posiciones.Add(new Point(sectionodo.Location.X + 100, sectionodo.Location.Y - sigPosicion));
                posiciones.Add(new Point(sectionodo.Location.X - 100, sectionodo.Location.Y - sigPosicion));

            }
        }

        private int promedio(int n1, int n2)
        {
            int resultato = n1 + n2;
            resultato = resultato / 2;
            return Math.Abs(resultato);
        }
        private bool validection(PictureBox origen, PictureBox destino,string color)
        {
            Point puntoOrigin = origen.Location;
            Point puntoDestino = destino.Location;

            int avance = puntoOrigin.Y - puntoDestino.Y;
            avance = color == "red" ? avance : (avance * -1);
            avance = sectionodo.Tag == "queen" ? Math.Abs(avance) : avance;

            if(avance == 50)
            {
                return true;
            }
            else if(avance == 100)
            {
                Point puntoMedio = new Point(promedio(puntoDestino.X, puntoOrigin.X), promedio(puntoDestino.Y, puntoOrigin.Y));
                List<PictureBox> bandoContrario = color == "red" ? Azuls : Ajaxs;

                for(int i=0; i < bandoContrario.Count; i++)
                {
                    if(bandoContrario[i].Location == puntoMedio)
                    {
                        bandoContrario[i].Location = new Point(0, 0);
                        bandoContrario[i].Visible = false;
                        return true;
                    }
                }
            }
            return false;
        }

        private void ifQueen(string color)
        {
            if (color == "red" && sectionodo.Location.Y == 400)
            {
                sectionodo.BackgroundImage = Properties.Resources.redQueen;
                sectionodo.Tag = "queen";
            }
            else if (color == "mavi" && sectionodo.Location.Y == 50)
            {
                sectionodo.BackgroundImage = Properties.Resources.maviQueen;
                sectionodo.Tag = "queen";
            }
        }

        private void SectionAzul(object sender, MouseEventArgs e)
        {
            section(sender);
        }

        private void SectionAjax(object sender, MouseEventArgs e)
        {
            section(sender);
        }
    }
}
