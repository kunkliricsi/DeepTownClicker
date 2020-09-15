using System;
using DeepTownClicker.Layer2.Interfaces;

namespace DeepTownClicker.Layer2
{
    public class Logger : ILogger
    {
        public void Write(char message)
        {
            Console.Write(message);
        }

        public void Write(string message)
        {
            if (message.Contains("\r"))
            {
                message = message.Replace("\r", "");
                Console.Write($"\r{DateTime.Now} - {message}");
            }
            else 
            {
                Console.Write(message);
            }
        }

        public void WriteLine() 
        {
            Console.WriteLine();
        }

        public void WriteLine(char message) 
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message) 
        {
            if (message.Contains("\n"))
            {
                message = message.Replace("\n", "");
                Console.WriteLine($"\n{DateTime.Now} - {message}");
            }
            else 
            {
                Console.WriteLine($"{DateTime.Now} - {message}");
            }
        }
    }
}