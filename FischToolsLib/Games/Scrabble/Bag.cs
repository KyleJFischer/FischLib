using FischToolsLib.Utilies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FischToolsLib.Game.Scrabble
{
    public class Bag
    {
        List<Tile> Tiles = new List<Tile>();

        public Bag(string File)
        {
            LoadBag(File);
        }
        public Bag()
        {
            LoadBag(@"Q:\DataFiles\Scrabble.txt");
        }

        internal void LoadBag(string file)
        {
            var lines = File.ReadLines(file);
            foreach(var line in lines)
            {
                var split = line.Split(',');
                var howMany = int.Parse(split[2]);
                var worth = int.Parse(split[1]);
                for (int i = 0; i < howMany; i++)
                {
                    Tiles.Add(new Tile(worth, split[0][0]));
                }
            }
        }

        internal void ShuffleBag()
        {
            Tiles.Shuffle();
        }

        public bool IsEmpty()
        {
            return !Tiles.Any();
        }

        internal Tile DrawTile()
        {
            var selectedTile = (Tile)Tiles.RandomItem();
            Tiles.Remove(selectedTile);
            return selectedTile;
        }
    }
}
