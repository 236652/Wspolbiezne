using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class Kulka : INotifyPropertyChanged
    {
        private int width;
        private int height;
        private int left;
        private int top;
        public event PropertyChangedEventHandler PropertyChanged;
        private static Random random = new Random();
        private int krokX = random.Next(-1, 1);
        private int krokY = random.Next(-1, 1);

        public Kulka(int width, int height, int left, int top) {
            this.width = width;
            this.height = height;
            this.left = left;
            this.top = top;
        }

        public int Width {
            get { return width; }
            set {
                width = value;
                RaisePropertyChanged("Width");
            }
        }

        public int Height {
            get { return height; }
            set {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        public int Left
        {
            get { return left; }
            set {
                left = value;
                RaisePropertyChanged("Left");
            }
        }

        public int Top
        {
            get { return top; }
            set {
                top = value;
                RaisePropertyChanged("Top");
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ruszKulkami(int width, int height)
        {
            int stop = 0;
            while (krokX == 0 || krokY == 0)
            {
                krokX = random.Next(-1, 1);
                krokY = random.Next(-1, 1);
            }
            if (this.Left + krokX == (width - 25)) {
                krokX = -1;
            }
            if (this.Top + krokY == (height - 25)) {
                krokY = -1;
            }
            if (this.Left + krokX == (0)) {
                krokX = 1;
            }
            if (this.Top - krokY == (0)) {
                krokY = 1;
            }
            this.Left = this.Left + krokX;
            this.Top = this.Top + krokY;
        }
    }
}