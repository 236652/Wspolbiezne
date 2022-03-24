using System;

namespace FirstProgram
{
    public class Calculator
    {
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