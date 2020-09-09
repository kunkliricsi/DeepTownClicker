using DeepTownClicker.Layer1;
using System;
using System.Linq;
using System.Threading;

namespace DeepTownClicker.Layer2
{
    public class GameLoopActions
    {
        private readonly GameActions _actions;

        public GameLoopActions(GameActions actions)
        {
            _actions = actions;
        }

        public void ClickAllSpellsLoop(CancellationToken cancellation, int times = 150)
        {
            Console.WriteLine("\nGoing to spells...");

            _actions.GoToSurface();
            Thread.Sleep(500);
            cancellation.ThrowIfCancellationRequested();

            _actions.SwipeDown();
            Thread.Sleep(100);
            cancellation.ThrowIfCancellationRequested();

            _actions.GoToSpells();
            Thread.Sleep(1000);
            cancellation.ThrowIfCancellationRequested();

            for (int i = 0; i < times; i++)
            {
                cancellation.ThrowIfCancellationRequested();

                _actions.ClickAllSpells();
                Console.Write($"\r({i}) Pressing spells...");
            }
        }

        public void ClaimMinesLoop(CancellationToken cancellation, params int[] mineLevels)
        {
            int i = 0;

            while (true)
            {
                Console.Write($"\n({++i}) Claiming [{mineLevels.Length}] mines: ");
                ClaimMines(cancellation, mineLevels);
            }
        }

        public void ClaimMinesAndPressSpellsLoop(CancellationToken cancellation, params int[] mineLevels)
        {
            int i = 0;

            while (true)
            {
                Console.Write($"\n({++i}) Claiming [{mineLevels.Length}] mines: ");
                ClaimMines(cancellation, mineLevels);

                ClickAllSpellsLoop(cancellation);
            }
        }

        private void ClaimMines(CancellationToken cancellation, params int[] mineLevels)
        {
            if (mineLevels.Length < 1)
                return;

            var mines = mineLevels.OrderBy(i => i).ToArray();

            cancellation.ThrowIfCancellationRequested();

            _actions.GoToSurface();
            Thread.Sleep(500);
            cancellation.ThrowIfCancellationRequested();

            _actions.SwipeDown();
            int currentLevel = 1;
            Thread.Sleep(100);
            cancellation.ThrowIfCancellationRequested();

            for (int j = 0; j < mines.Length; j++)
            {
                cancellation.ThrowIfCancellationRequested();

                for (int k = 0; k < mines[j] - currentLevel; k++)
                {
                    cancellation.ThrowIfCancellationRequested();
                    _actions.GoDown();
                    Console.Write('.');
                }

                cancellation.ThrowIfCancellationRequested();

                currentLevel = mines[j];

                Thread.Sleep(200);
                _actions.ClickClaim();

                Console.Write($"{currentLevel}");
            }
        }
    }
}
