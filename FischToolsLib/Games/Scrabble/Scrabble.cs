using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FischToolsLib.Languages;

namespace FischToolsLib.Game.Scrabble
{
    public class ScrabbleGame
    {
        Bag bag = null;
        Library ValidLanguages = null;
        List<Player> players = null;
        int MaxTiles = 7;

        public ScrabbleGame()
        {
            bag = new Bag();
            ValidLanguages = new Library();
            players = new List<Player>();
            players.Add(new Player($"Player1"));
        }
        public ScrabbleGame(int PlayerCount)
        {
            bag = new Bag();
            ValidLanguages = new Library();
            players = new List<Player>();
            for(int i = 0; i < PlayerCount; i++)
            {
                players.Add(new Player($"Player{i}"));
            }
        }

        public void AddValidLanguage(Language lang)
        {
            ValidLanguages.AddLanguage(lang);
        }

        public void DealTiles()
        {
            foreach(var player in players)
            {
                while (!bag.IsEmpty() && player.NumberOfTiles() < MaxTiles)
                {
                    player.AddTile(bag.DrawTile());
                }
            }
        }

        public Player GetPlayer(int playerNumber)
        {
            return players[playerNumber];
        }

        public Library GetValidLanguages()
        {
            return ValidLanguages;
        }

        public List<Player> PlayGameAndGetWinners()
        {

            while (!bag.IsEmpty())
            {
                DealTiles();
                players.ForEach(m => m.PlayHighestPointWord(ValidLanguages));
            }
            return players.Where(m => m.GetScore() == players.Max(z => z.GetScore())).ToList();
        }
    }
}
