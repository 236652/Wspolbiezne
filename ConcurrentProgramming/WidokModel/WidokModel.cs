using System;
using System.Windows.Input;
using Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WidokModel
{
    public class WidokModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ModelAbstractApi newModel;
        private ObservableCollection<Kula> kule;
        private int height;
        private int width;
        private int left;
        private int top;
        public ICommand Start { get; set;}
        public ICommand Stop { get; set;}

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WidokModel()
        {
            newModel = ModelAbstractApi.CreateApi();
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            this.Width = 25;
            this.Height = 25;
            this.Top = 160;
            this.Left = 90;
        }


        public int Height
        {
            get { return height; }
            set { height = value; RaisePropertyChanged("Height"); }
        }

        public int Width
        {
            get { return width; }
            set { width = value; RaisePropertyChanged("Width"); }
        }

        public int Left
        {
            get { return left; }
            set { left = value; RaisePropertyChanged("Left"); }
        }

        public int Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged("Top"); }
        }

        public void start()
        {
            newModel.start(320, 230, 4);
            this.kule = newModel.getKula();
            foreach (Kula k in this.kule)
            {
                this.Left = k.Left;
                this.Top = k.Top;
            }
        }

        public void stop()
        {
            newModel.getKula().Clear();
            newModel.stop();
        }
        public ObservableCollection<Kula> Kule
        {
            get { return kule; }
            set { kule = value;
                //RaisePropertyChanged("Kule");
            }
        }
    }
}
