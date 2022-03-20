using System;

namespace FirstProgram
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            var userInput = "";
            var x = "";
            var y = "";
            Calculator cal = new Calculator();
            do
            {
                Console.WriteLine("1.Dodaj");
                Console.WriteLine("2.Odejmij");
                Console.WriteLine("3.Wyjdz");
                Console.Write("Wybor: ");
                userInput = Console.ReadLine();
                Console.Clear();
                switch(userInput)
                {
                    case "1":
                        Console.Write("Podaj x: ");
                        x = Console.ReadLine();
                        Console.Write("\nPodaj y: ");
                        y = Console.ReadLine();
                        Console.WriteLine(cal.add(Int32.Parse(x), Int32.Parse(y)));
                        break;
                    case "2":
                        Console.Write("Podaj x: ");
                        x = Console.ReadLine();
                        Console.Write("\nPodaj y: ");
                        y = Console.ReadLine();
                        Console.WriteLine(cal.sub(Int32.Parse(x), Int32.Parse(y)));
                        break;
                }
            } while (userInput != "3");
        }

        public int add(int x, int y)
        {
            return x + y;
        }
        public int sub(int x, int y)
        {
            if (x < y)
            {
                int temp = x;
                x = y;
                y = temp;
            }
            return x - y;
        }
        
        public void exc(bool x)
        {
            if (x)
            {
                throw new Exception();
            }
        }
    }
}
