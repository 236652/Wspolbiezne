using System;
using Dane;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class KulkaMerge
    {
        private int width;
        private int height;
        private int left;
        private int top;
        private int krokX;
        private int krokY;
        private Kulka kulka;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public KulkaMerge(Kulka kulka)
        {
            this.kulka = kulka;
            this.krokX = kulka.KrokX;
            this.krokY = kulka.KrokY;
            this.Left = kulka.Left; 
            this.Top = kulka.Top;
            this.Width = kulka.Width;
            this.Height = kulka.Height;
          
            kulka.PropertyChanged += OnPropertyChanged;
        }

        public int Left
        {
            get { return this.left; }
            set
            {
                this.left = value;
                RaisePropertyChanged("Left");
            }
        }

        public int Top
        {
            get { return this.top; }
            set
            {
                this.top = value;
                RaisePropertyChanged("Top");
            }
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                RaisePropertyChanged("Width");
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                RaisePropertyChanged("Height");
            }
        }

        public int KrokX
        {
            get { return this.krokX; }
            set
            {
                this.krokX = value;
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

        public void Move()
        {
            this.Top += this.KrokX;
            this.Left += this.KrokY;
            RaisePropertyChanged("zmiana");
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Kulka k = (Kulka)sender;

            switch (e.PropertyName)
            {
                case "KrokX":
                    KrokX = k.KrokX;
                    break;
                case "KrokY":
                    KrokY = k.KrokY;
                    break;
                case "Top":
                    Top = k.Top;
                    break;
                case "Left":
                    Left = k.Left;
                    break;
            }
        }
    }
}
