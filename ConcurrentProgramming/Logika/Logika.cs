using Dane;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;

namespace Logika
{
    public abstract class LogikaAbstractApi
    {
        public static LogikaAbstractApi createApi(DaneAbstractApi daneAbstractApi = null)
        {
            return new LogikaApi(daneAbstractApi);
        }
        public abstract void stwozCanvas(int width, int height, int ilosc);
        public abstract void Start();

        public abstract void Stop();
        public abstract List<KulkaMerge> getKulkiMerges();

        public abstract Canvas getCanvas();

        public class LogikaApi : LogikaAbstractApi
        {
            private DaneAbstractApi daneApi;
            private List<Thread> watki = new List<Thread>();
            private List<KulkaMerge> kulkaMerges = new List<KulkaMerge>();
            private static Random random = new Random();

            public LogikaApi(DaneAbstractApi daneAbstractApi = null)
            {
                this.daneApi = DaneAbstractApi.createApi();
            }

            public override void stwozCanvas(int width, int height, int ilosc)
            {
                this.kulkaMerges.Clear();
                this.daneApi.stwozCanvas(width, height, ilosc);
                foreach(Kulka k in this.daneApi.getCanvas().getKulki())
                {
                    this.kulkaMerges.Add(new KulkaMerge(k));
                    k.PropertyChanged += ruch;
                }
            }

            public override Canvas getCanvas()
            {
                return this.daneApi.getCanvas();
            }

            private void AktualizujWektorPrzesuniecia(int height, int width, Kulka kulka)
            {
                int vectorX1, vectorX2, vectorY1, vectorY2;
                granicePlanszy(kulka, width, height);
                foreach (Kulka kolizja in this.daneApi.getCanvas().getKulki())
                {
                    if (!kolizja.Equals(kulka))
                    {
                        double odleglosc = Math.Sqrt((kulka.Top - kolizja.Top) * (kulka.Top - kolizja.Top) + (kulka.Left - kolizja.Left) * (kulka.Left - kolizja.Left));
                        if (odleglosc <= 25)
                        {
                            vectorX1 = (kulka.KrokX * (kulka.Mass - kolizja.Mass) / (kulka.Mass + kolizja.Mass) + (2 * kolizja.Mass * kolizja.KrokX) / (kulka.Mass + kolizja.Mass));
                            vectorY1 = (kulka.KrokY * (kulka.Mass - kolizja.Mass) / (kulka.Mass + kolizja.Mass) + (2 * kolizja.Mass * kolizja.KrokY) / (kulka.Mass + kolizja.Mass));
                            vectorX2 = (kolizja.KrokX * (kolizja.Mass - kulka.Mass) / (kulka.Mass + kolizja.Mass) + (2 * kulka.Mass * kulka.KrokX) / (kulka.Mass + kolizja.Mass));
                            vectorY2 = (kolizja.KrokY * (kolizja.Mass - kulka.Mass) / (kulka.Mass + kolizja.Mass) + (2 * kulka.Mass * kulka.KrokY) / (kulka.Mass + kolizja.Mass));

                            kulka.KrokX = vectorX1;
                            kulka.KrokY = vectorY1;
                            kolizja.KrokX = vectorX2;
                            kolizja.KrokY = vectorY2;
                        }
                    }
                }
            }

            public void ruch(object sender, PropertyChangedEventArgs e)
            {
                Kulka k = (Kulka)sender;
                if (e.PropertyName == "zmiana") { 
                    AktualizujWektorPrzesuniecia(this.daneApi.getCanvas().getHeight(), this.daneApi.getCanvas().getWidth(), k);
                }
            }

            public void granicePlanszy(Kulka kulka, int width, int height)
            {
                while (kulka.KrokY == 0 || kulka.KrokY == 0)
                {
                    kulka.KrokX = random.Next(-1, 2);
                    kulka.KrokY = random.Next(-1, 2);
                }
                if (kulka.Left + kulka.KrokX == (width - 25))
                {
                    kulka.KrokX *= -1;
                }
                if (kulka.Top + kulka.KrokY == (height - 25))
                {
                    kulka.KrokY *= -1;
                }
                if (kulka.Left + kulka.KrokX == (0))
                {
                    kulka.KrokX *= -1;
                }
                if (kulka.Top + kulka.KrokY == (0))
                {
                    kulka.KrokY *= -1;
                }
            }

            public override void Start()
            {
                this.daneApi.Start();
            }

            public override void Stop()
            {
                this.daneApi.Stop();
            }

            public override List<KulkaMerge> getKulkiMerges()
            {
                return this.kulkaMerges;
            }
        }
    }
}
