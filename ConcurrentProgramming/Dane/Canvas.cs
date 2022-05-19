using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Canvas
    {
        private int height;
        private int width;
        private List<Kulka> kulki = new List<Kulka>();

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

        public void stwozKulki(int ilosc)
        {
            Random random = new Random();
            for (int j = 0; j < ilosc; j++)
            {
                int left = random.Next(25, width - 25);
                int top = random.Next(25, height - 25);
                while (!moznaStwozyc(left, top))
                {
                    left = random.Next(25, width - 25);
                    top = random.Next(25, height - 25);
                }
                kulki.Add(new Kulka(25, 25, left, top));
            }
        }
        
        public bool moznaStwozyc(int left, int top)
        {
            foreach(Kulka kulka in this.kulki)
            {
                bool left1 = (left <= (kulka.Left + 50));
                bool left2 = (left >= (kulka.Left - 50));
                bool top1 = (top <= (kulka.Top + 50));
                bool top2 = (top >= (kulka.Top - 50));
                if ((left1 && left2) && (top1 && top2))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
