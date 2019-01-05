using FischToolsLib.Languages;
using FischToolsLib.Utilies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FischToolsLib.Game.Scrabble
{
    public class Player
    {
        List<Tile> Tiles = new List<Tile>();
        string Name = "";
        int Score = 0;

        public Player(string name)
        {
            Name = name;
        }
        
        public int GetScore()
        {
            return Score;
        }

        public string GetName()
        {
            return Name;
        }

        public int NumberOfTiles()
        {
            return Tiles.Count;
        }

        public void AddTile(Tile tile)
        {
            this.Tiles.Add(tile);
        }

        public bool HaveLetters(string word)
        {
            var wordToUpper = word.ToUpper();
            foreach(var tile in Tiles)
            {
                var index = wordToUpper.IndexOf(tile.Letter);
                if (index != -1)
                {
                    wordToUpper = wordToUpper.Remove(index);
                }
            }
            if (String.IsNullOrWhiteSpace(wordToUpper))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetTilesAsString()
        {
            var result = "";
            foreach(var tile in Tiles)
            {
                result += tile.ToString();
            }
            return result;
        }

        public bool IsWordValid(string word, Library lib)
        {
            return (HaveLetters(word) && lib.DoesWordExistInAnyLanguages(word));
        }

        public int PlayTile(char letter)
        {
            var tile = Tiles.FirstOrDefault(m => m.Letter == letter);
            Tiles.Remove(tile);
            return tile.Point;
        }

        public int CalculateTotal(string word)
        {
            var score = 0;
            foreach (var letter in word.ToUpper())
            {
                var tile = Tiles.FirstOrDefault(m => m.Letter == letter);
                score += tile.Point;
            }
            return score;
        }

        public int PlayWord(string word, Library lib)
        {
            if (!IsWordValid(word, lib)){
                return -1;
            }
            var score = 0;
            foreach (var letter in word.ToUpper())
            {
                score += PlayTile(letter);
            }
            this.Score += score;
            return score;
        }

        public Dictionary<string, int> AllPossibleWords(Library lib)
        {
            var stringTiles = GetTilesAsString();
            var listStrings = lib.GetAllWordsFromScramble(stringTiles).Distinct().ToList();
            var result = new Dictionary<string, int>();
            listStrings.ForEach(m => result.Add(m, CalculateTotal(m)));
            return result;
        }

        public Dictionary<string, int> GetHighestScoreWords(Library lib)
        {
            var possibleWords = AllPossibleWords(lib);
            var maxValue = possibleWords.Values.Max();
            return possibleWords.Where(m => m.Value == maxValue).ToDictionary(m => m.Key, m => m.Value);
        }

        public int PlayHighestPointWord(Library lib)
        {
            var wordsToChoose = GetHighestScoreWords(lib).Keys.ToList();
            var randomWord = (string)wordsToChoose.RandomItem();
            return PlayWord(randomWord, lib);
        }
    }
}
