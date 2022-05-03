using System;
using System.Threading;

namespace Synkroniserings_øvelse_2
{
    class Program
    {

        static int count = 0;
        static object printLock = new object();


        static void Main(string[] args)
        {
            var t1 = new Thread(Print);
            var t2 = new Thread(Print);

            t1.Start("*");
            Thread.Sleep(10);
            t2.Start("#");
        }

        static void Print(object print)
        {
            while (true)
            {
                lock (printLock)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        count++;
                        Console.Write(print);
                        Thread.Sleep(10);
                    }

                    Console.WriteLine($" {count}");
                }
            }

        }
    }
}
