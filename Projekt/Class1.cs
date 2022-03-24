using System;

namespace Projekt
{
    public class Class1
    {
        public int add(int x, int y)
        {
            return x + y;
        }

        public int subtract(int x, int y)
        {
            return x - y;
        }

        public int pow(int x, int y)
        {   int score =1;
            for (int i = 0; i < y; i++)
            {
                score *= x;
            }
            return score;
        }
        
         
    }
}
