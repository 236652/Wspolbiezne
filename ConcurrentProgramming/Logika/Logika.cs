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

        public abstract void Stop();

        public abstract Canvas getCanvas();

        public class LogikaApi : LogikaAbstractApi
        {
            private DaneAbstractApi daneApi;
            private Canvas canvas;
            private List<Thread> watki;

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
                this.canvas.setOn(true);
                foreach (Kulka kulka in this.canvas.getKulki())
                {
                    Thread t = new Thread(() =>
                    {
                        while (this.canvas.getOn())
                        {
                            kulka.ruszKulkami(this.canvas.getWidth(), this.canvas.getHeight());
                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }

            public override void Stop()
            {
                this.canvas.setOn(false);
            }
        }
    }
}
