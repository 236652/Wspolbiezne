using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Canvas
    {
        private int height;
        private int width;
        private List<Kulka> kulki = new List<Kulka> ();

        public int getWidth()
        {
            return width;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public List<Kulka> getKulki()
        {
            return kulki;
        }
        
        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /*public Boolean getOn()
        {
            return this.isOn;
        }

        public void setOn(Boolean isOn)
        {
            this.isOn = isOn;
        }*/

        public void stwozKulki(int ilosc)
        {
            Random random = new Random();
            for (int j = 0; j < ilosc; j++)
            {
                int left = random.Next(25, width - 25);
                int top = random.Next(25, height - 25);
                kulki.Add(new Kulka(25, 25, left, top));
            }
        }

        public void ruszKulkami()
        {
            Random random = new Random();
            foreach (Kulka kulka in kulki)
            {
                int x = 0;
                int y = 0;
                while (x == 0 && y == 0)
                {
                    x = random.Next(-1, 1);
                    y = random.Next(-1, 1);

                    if (kulka.Left + y < 25 || kulka.Left + y > width - 25 || kulka.Top + x < 25 || kulka.Top + x > width - 25)
                    {
                        x = 0;
                    }
                }
                kulka.Left = kulka.Left + y;
                kulka.Top = kulka.Top + x;
            }
        }
    }
}
