using Dane;

namespace Logika
{
    public abstract class LogikaAbstractApi
    {
        public static LogikaAbstractApi createApi(DaneAbstractApi daneAbstractApi = null)
        {
            return new LogikaApi(daneAbstractApi);
        }
        public abstract void stwozCanvas(int width, int height, int ilosc);
        public abstract void ruszKulkami();

        public abstract void Start();

        public abstract void Stop();

        public abstract Canvas getCanvas();

        public class LogikaApi : LogikaAbstractApi
        {
            private DaneAbstractApi daneApi;
            private Canvas canvas;
            private List<Thread> watki;
            private Boolean isOn;

            public LogikaApi(DaneAbstractApi daneAbstractApi = null)
            {
                this.daneApi = DaneAbstractApi.createApi();
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

            public override void ruszKulkami()
            {
                watki = new List<Thread>();
                foreach (Kulka kulka in this.canvas.getKulki())
                {
                    Thread t = new Thread(() =>
                    {
                        while (isOn)
                        {
                            this.canvas.ruszKulkami();
                            Thread.Sleep(5);
                        }
                    });
                    this.watki.Add(t);
                }
            }

            public override void Start()
            {
                if (!isOn)
                {
                    isOn = true;
                    foreach (Thread t in watki)
                    {
                        t.Start();
                    }
                }
            }

            public override void Stop()
            {
                isOn = false;
            }
        }
    }
}
