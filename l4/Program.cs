using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace l4
{
    class Program
    {
        static int x = 0;
        static object locker = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count); // Create Thread
                myThread.Name = "Thread " + i.ToString();
                myThread.Start();
            }

            Console.ReadLine();
        }

        public static void Count()
        {
            lock (locker) // Lock resource
            {
                x = 1;
                for (int i = 1; i < 11; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
