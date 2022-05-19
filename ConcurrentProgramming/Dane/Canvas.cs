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
                kulki.Add(new Kulka(25, 25, left, top));
            }
        }
    }
}
