using Logika;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi(LogikaAbstractApi logika = default)
        {
            return new Model(logika ?? LogikaAbstractApi.createApi());
        }

        public abstract ObservableCollection<Kula> getKula();

        public abstract void stop();

        public abstract void start(int width, int height, int ilosc);

        public class Model : ModelAbstractApi
        {
            private LogikaAbstractApi warstwaLogiki;
            private ObservableCollection<Kula> kule = new ObservableCollection<Kula>();

            public Model(LogikaAbstractApi logika)
            {
                warstwaLogiki = logika;
            }

            public override ObservableCollection<Kula> getKula()
            {
                return kule;
            }

            public override void start(int width, int height, int ilosc)
            {
                kule.Clear();
                warstwaLogiki.stwozCanvas(width, height, ilosc);
                warstwaLogiki.ruszKulkami();

                foreach (Kulka k in warstwaLogiki.getCanvas().getKulki())
                {
                    kule.Add(new Kula(k));
                }
            }

            public override void stop()
            {
                warstwaLogiki.Stop();
            }
        }
    }
}
