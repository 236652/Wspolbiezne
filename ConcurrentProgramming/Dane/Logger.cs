using System.Text.Json;
using System.Diagnostics;

namespace Dane
{
    public class Logger
    {
        private List<Kulka> kuli;
        private bool isLogging;
        private Stopwatch stopwatch = new Stopwatch();

        public void StartLog(List<Kulka> kulki)
        {
            this.isLogging = true;
            this.kuli = kulki;
            this.WriteLog();
        }

        public void StopLog()
        {
            this.stopwatch.Stop();
            this.stopwatch.Restart();
            this.isLogging = false;
        }

        public void WriteToFile(List<Kulka> kulki)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\piotr\\OneDrive\\Pulpit\\Studia\\Semestr 4\\Programowanie Współbieżne\\Wspolbiezne\\Logs\\logs.txt", true))
            {
                foreach (Kulka k in kulki)
                {
                    writer.WriteLine($"{DateTime.Now:o} : {JsonSerializer.Serialize(k)}");
                }
            }
        }

        public void WriteLog() 
        {
            Thread t = new Thread(() =>
            {
                stopwatch.Start();
                while (isLogging)
                {
                    if (stopwatch.ElapsedMilliseconds >= 5)
                    {
                        stopwatch.Restart();
                        this.WriteToFile(this.kuli);
                    }
                }
            });
            t.Start();
        }
    }
}
