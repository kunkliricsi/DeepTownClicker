using System;
using System.Threading;
using DeepTownClicker.Layer0;
using DeepTownClicker.Layer1;
using DeepTownClicker.Layer2;

namespace DeepTownClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var adb = new ADB();
            var actions = new GameActions(adb);
            var logger = new Logger();
            var loops = new GameLoopActions(actions, logger);
            var cancellationSource = new CancellationTokenSource();

            loops.ClaimMinesAndPressSpellsLoop(cancellationSource.Token,
                1, 4, 7, 10, 13, 16, 19, 22, 25,
                28, 31, 34, 37, 40, 43, 46, 49, 52);
        }
    }
}
