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
        private ObservableCollection<Kula> kule = new ObservableCollection<Kula>();
        private int height;
        private int width;
        private int left;
        private int top;
        private int liczbaKul;
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
        }

        public int LiczbaKul
        {
            get { return this.liczbaKul; }
            set { this.liczbaKul = value; RaisePropertyChanged("LiczbaKul"); }
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
            newModel.getKula().Clear();
            newModel.start(320, 230, LiczbaKul);
            this.Kule = newModel.getKula();
        }

        public void stop()
        { 
            newModel.stop();
        }
        public ObservableCollection<Kula> Kule
        {
            get { return kule; }
            set { kule = value;
                RaisePropertyChanged("Kule");
            }
        }
    }
}
