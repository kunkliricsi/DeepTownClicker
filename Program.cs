using System;
using DeepTownClicker.Core;
using System.Threading;

namespace DeepTownClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var adb = new ADB();

            int i = 0;
            while (true) 
            {
                adb.Click(620, 2230);
                Console.Write($"\rPressing shit... {++i}");
                Thread.Sleep(640);
            }
        }
        
    }
}
