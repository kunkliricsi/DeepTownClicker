using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DeepTownClicker
{
    public class GameLoops
    {
        private readonly GameActions _actions;

        public GameLoops(GameActions actions)
        {
            _actions = actions;
        }

        public void ClickAllSpellsLoop(CancellationToken cancellation)
        {
            int i = 0;

            while (true)
            {
                cancellation.ThrowIfCancellationRequested();

                _actions.ClickAllSpells();
                Console.Write($"\rPressing spells... {++i}");
            }
        }

        public void ClaimMinesLoop(CancellationToken cancellation, params int[] mineLevels)
        {
            if (mineLevels.Length < 1)
                return;

            var mines = mineLevels.OrderBy(i => i).ToArray();

            int i, currentLevel;

            while (true)
            {
                i = 0;

                cancellation.ThrowIfCancellationRequested();

                _actions.GoToSurface();

                Thread.Sleep(1000);
                _actions.SwipeDown();
                currentLevel = 1;
                Thread.Sleep(100);

                cancellation.ThrowIfCancellationRequested();

                for (int j = 0; j < mines.Length; j++)
                {
                    cancellation.ThrowIfCancellationRequested();

                    for (int k = 0; k < mines[j] - currentLevel; k++)
                    {
                        cancellation.ThrowIfCancellationRequested();
                        _actions.GoDown();
                    }

                    cancellation.ThrowIfCancellationRequested();

                    currentLevel = mines[j];

                    Thread.Sleep(200);
                    _actions.ClickClaim();
                }

                Console.Write($"\rClaiming mines... {++i}");
            }
        }
    }
}
