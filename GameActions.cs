﻿using DeepTownClicker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTownClicker
{
    public class GameActions
    {
        private readonly ADB _adb;

        public GameActions(ADB adb)
        {
            _adb = adb;
        }

        public void ClickAllSpells()
        {
            ClickButton(
                Button.SpellOne,
                Button.SpellTwo,
                Button.SpellThree,
                Button.SpellFour
            );
        }

        public void GoDown()
        {
            ClickButton(Button.GoDown);
        }

        public void GoUp()
        {
            ClickButton(Button.GoUp);
        }

        public void ClickClaim()
        {
            ClickButton(Button.ClaimMine);
        }

        public void ClickButton(params Button[] buttons)
        {
            foreach (var button in buttons)
                ClickButton(button);
        }

        public void ClickButton(Button button)
        {
            _adb.Click(button.X, button.Y);
        }
    }
}
