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
        private int krokX;
        private int krokY;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Kula(KulkaMerge kulkaMerge)
        {
            this.Left = kulkaMerge.Left;
            this.Top = kulkaMerge.Top;
            this.Width = kulkaMerge.Width;
            this.Height = kulkaMerge.Height;
            this.krokX = kulkaMerge.KrokX;
            this.krokY = kulkaMerge.KrokY; 
            kulkaMerge.PropertyChanged += OnPropertyChanged;
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

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            KulkaMerge k = (KulkaMerge)sender;

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
