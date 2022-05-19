using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Kulka
    {
        private int width;
        private int height;
        private int left;
        private int top;
        private int mass = 1;
        public event PropertyChangedEventHandler PropertyChanged;
        private static Random random = new Random();
        private int krokX = random.Next(-1, 2);
        private int krokY = random.Next(-1, 2);

        public void Move()
        {
            this.Left += this.KrokX;
            this.Top += this.KrokY;
            RaisePropertyChanged("zmiana");
        }


        public Kulka(int width, int height, int left, int top)
        {
            this.width = width;
            this.height = height;
            this.left = left;
            this.top = top;
        }

        public int Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public int KrokX
        {
            get { return this.krokX; }
            set { this.krokX = value;
                RaisePropertyChanged("KrokX");
            }
        }

        public int KrokY
        {
            get { return this.krokY; }
            set
            {
                this.krokY = value;
                RaisePropertyChanged("KrokY");
            }
        }

        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        public int Left
        {
            get { return left; }
            set
            {
                left = value;
                RaisePropertyChanged("Left");
            }
        }

        public int Top
        {
            get { return top; }
            set
            {
                top = value;
                RaisePropertyChanged("Top");
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
