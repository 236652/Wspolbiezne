using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.IO;


namespace Dane
{
    public class Logger
    {
        private object zamek = new object();
        public void WriteLog(string message)
        {
            using(StreamWriter writer = new StreamWriter("\\.\\Wspolbiezne\\Logs\\logs.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}
