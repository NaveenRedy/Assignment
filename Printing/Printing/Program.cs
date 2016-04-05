using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)

            {

                if (i % 2 == 0 || i % 7 == 0)

                {
                    if (i % 2 == 0 && i % 7 == 0)
                    {
                        Console.WriteLine("CrossShield");


                    }
                    else if (i % 2 == 0)
                    {
                        Console.WriteLine("Cross");

                    }
                    else
                    {
                        Console.WriteLine("Shield");
                    }
                }

                else
                {
                    Console.WriteLine(i);
                }
              
            }
            Console.ReadLine();

        }
    }
   
}
