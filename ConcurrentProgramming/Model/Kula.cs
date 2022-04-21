using System;
using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Kula : INotifyPropertyChanged
    {
        private int width;
        private int height;
        private int left;
        private int top;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Kula(Kulka kulka)
        {
            this.Left = kulka.Left;
            this.Top = kulka.Top;
            this.Width = kulka.Width;
            this.Height = kulka.Height;
            kulka.PropertyChanged += OnPropertyChanged;
        }

        

        public int Left
        {
            get { return this.left; }
            set { this.left = value;
                RaisePropertyChanged("Left");
            }
        }

        public int Top
        {
            get { return this.top; }
            set { this.top = value;
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
                this.height=value;
                RaisePropertyChanged("Height");
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Kulka k = (Kulka)sender;

            switch (e.PropertyName)
            {
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
