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
       
    }
}