using System;
using System.Collections.Generic;
using System.Text;

namespace FischToolsLib.Game.Scrabble
{
    public class Tile
    {
        public int Point;
        public char Letter;

        public Tile(int pt, char letter)
        {
            Point = pt;
            Letter = letter;
        }
        public override string ToString()
        {
            return Letter.ToString();
        }
    }
}
