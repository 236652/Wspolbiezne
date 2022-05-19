using System;

namespace Dane
{
    public abstract class DaneAbstractApi
    {
        public static DaneAbstractApi createApi()
        {
            return new DaneApi();
        }

        public abstract void stwozCanvas(int width, int height, int ilosc);
        public abstract void moveKulka();

        public abstract Canvas getCanvas();
        public abstract void Start();
        public abstract void Stop();

        public abstract void stwozKulki(int ilosc);
    }

    internal class DaneApi : DaneAbstractApi
    {
        private Canvas canvas;
        private bool isActive = false;
        private object zamek = new object();
        private List<Thread> threads = new List<Thread>();

        public bool IsActive 
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public override void stwozKulki(int ilosc)
        {
            this.getCanvas().getKulki().Clear();
            this.getCanvas().stwozKulki(ilosc);
        }

        public override void moveKulka()
        {
            foreach(Kulka kulka in this.canvas.getKulki())
            {
                Thread t = new Thread(() =>
                {
                    while (isActive)
                    {
                        lock (zamek)
                        {
                            kulka.Move();
                        }
                        Thread.Sleep(5);
                    }
                });
                this.threads.Add(t);
            }
        }

        public override void Start()
        {
            isActive = true;
            this.threads.Clear();
            this.moveKulka();
            foreach(Thread t in this.threads)
            {
                t.Start();
            }
        }

        public override void Stop()
        {
            isActive = false;
        }

        public override void stwozCanvas(int width, int height, int ilosc)
        {
            this.canvas = new Canvas(width, height);
            this.canvas.stwozKulki(ilosc);
        }

        public override Canvas getCanvas()
        {
            return this.canvas;
        }

    }
}