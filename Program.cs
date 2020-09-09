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
            var actions = new GameActions(adb);

            int i = 0;
            while (true)
            {
                for (int j = 0; j < 17; j++)
                {
                    actions.ClickClaim();

                    for (int k = 0; k < 3; k++)
                    {
                        if (i % 2 == 0)
                        {
                            actions.GoDown();
                        }
                        else
                        {
                            actions.GoUp();
                        }

                    }
                }

                Console.Write($"\rClaiming shit... {++i}");
            }
        }
    }
}
