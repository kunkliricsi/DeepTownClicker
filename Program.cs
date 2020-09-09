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
            var loops = new GameLoops(actions);
            var cancellationSource = new CancellationTokenSource();

            loops.ClaimMinesLoop(cancellationSource.Token,
                1, 4, 7, 10, 13, 16, 19, 22, 25,
                28, 31, 34, 37, 40, 43, 46, 49, 52);
        }
    }
}
