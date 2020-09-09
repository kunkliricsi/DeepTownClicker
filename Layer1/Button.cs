using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeepTownClicker.Layer1
{
    public class Button
    {
        public int X { get; }
        public int Y { get; }

        public Button(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Button SpellOne = new Button(275, 2230);
        public static Button SpellTwo = new Button(450, 2230);
        public static Button SpellThree = new Button(620, 2230);
        public static Button SpellFour = new Button(800, 2230);

        public static Button Surface = new Button(1010, 860);
        public static Button GoDown = new Button(1010, 1160);
        public static Button GoUp = new Button(1010, 960);
        public static Button Mine = new Button(1010, 1260);

        public static Button ClaimMine = new Button(960, 2222);
    }
}
