using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Dane;
using Logika;

namespace ModelTest
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void KulaTest()
        {
            Kulka kulkaTest = new Kulka(1, 2, 3, 4);
            KulkaMerge kulkaMergeTest = new KulkaMerge(kulkaTest);
            Kula kulaTest = new Kula(kulkaMergeTest);
            Assert.AreEqual(kulaTest.Width, kulkaTest.Width);
            Assert.AreEqual(kulaTest.Height, kulkaTest.Height);
            Assert.AreEqual(kulaTest.Left, kulkaTest.Left);
            Assert.AreEqual(kulaTest.Top, kulkaTest.Top);
            kulaTest.Width = 12;
            kulaTest.Height = 12;
            kulaTest.Left = 12;
            kulaTest.Top = 12;
            Assert.AreEqual(kulaTest.Width, 12);
            Assert.AreEqual(kulaTest.Height, 12);
            Assert.AreEqual(kulaTest.Left, 12);
            Assert.AreEqual(kulaTest.Top, 12);
        }

        [TestMethod]
        public void ModelT()
        {
            ModelAbstractApi modelTest = ModelAbstractApi.CreateApi();
            modelTest.start(1000, 1000, 1);
            Assert.AreEqual(modelTest.getKula().Count, 1);
            Assert.AreEqual(modelTest.getKula()[0].Width, 25);
            Assert.AreEqual(modelTest.getKula()[0].Height, 25);
        }
    }

    [TestClass]
    public class LogikaTest
    {
        [TestMethod]
        public void CanvasTest()
        {
            Canvas canvasTest = new Canvas(1000, 1000);
            Assert.AreEqual(canvasTest.getHeight(), 1000);
            Assert.AreEqual(canvasTest.getWidth(), 1000);
            canvasTest.stwozKulki(2);
            Assert.AreEqual(canvasTest.getKulki().Count, 2);
            canvasTest.setHeight(100);
            canvasTest.setWidth(100);
            Assert.AreEqual(canvasTest.getHeight(), 100);
            Assert.AreEqual(canvasTest.getWidth(), 100);
        }

        [TestMethod]
        public void LogikaAbstractApiTest()
        {
            LogikaAbstractApi logikaTest = LogikaAbstractApi.createApi();
            logikaTest.stwozCanvas(1000, 1000, 1);
            Assert.AreEqual(logikaTest.getCanvas().getHeight(), 1000);
            Assert.AreEqual(logikaTest.getCanvas().getWidth(), 1000);
            Assert.AreEqual(logikaTest.getCanvas().getKulki().Count, 1);
            int x = logikaTest.getCanvas().getKulki()[0].Left;
            Assert.AreEqual(x, logikaTest.getCanvas().getKulki()[0].Left);
        }
    }

    [TestClass]
    public class DaneTest
    {
        [TestMethod]
        public void CanvasTest()
        {
            Canvas canvasTest = new Canvas(200, 200);
            Kulka kulkaTest1 = new Kulka(25, 25, 30, 30);
            canvasTest.getKulki().Add(kulkaTest1);
            Assert.AreEqual(canvasTest.moznaStwozyc(31, 32), false);
            Canvas canvasTest1 = new Canvas(300, 300);
            canvasTest1.stwozKulki(2);
            Assert.AreEqual(canvasTest1.getKulki().Count, 2);
        }

        [TestMethod]
        public void KulkaTest()
        {
            Kulka kulka = new Kulka(25, 25, 25, 25);
            Assert.AreEqual(kulka.Height, 25);
            Assert.AreEqual(kulka.Width, 25);
            Assert.AreEqual(kulka.Left, 25);
            Assert.AreEqual(kulka.Top, 25);
            kulka.Width = 100;
            kulka.Height = 100;
            kulka.Left = 100;
            kulka.Top = 100;
            Assert.AreEqual(kulka.Height, 100);
            Assert.AreEqual(kulka.Width, 100);
            Assert.AreEqual(kulka.Left, 100);
            Assert.AreEqual(kulka.Top, 100);
        }

        [TestMethod]
        public void daneTest()
        {
            DaneAbstractApi daneTest = DaneAbstractApi.createApi();
            daneTest.stwozCanvas(200, 200, 2);
            Assert.IsNotNull(daneTest);
            Assert.AreEqual(daneTest.getCanvas().getKulki().Count, 2);
        }
    }
}