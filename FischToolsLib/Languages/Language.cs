using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FischToolsLib.Languages
{
    public class Language
    {
        static Dictionary<string, int> Words = null;
        private static char[] Vowels = { 'A', 'E', 'I', 'O', 'U', 'Y' };
        private string DICTIONARY_LOCATION = @"Q:\DataFiles\EnglishWords.txt";
        public string Name = "English";

        public Language(string FileLocation, char[] vowels, string name)
        {
            Vowels = vowels;
            DICTIONARY_LOCATION = FileLocation;
            Name = name;
        }
        public Language(string FileLocation, string name)
        {
            DICTIONARY_LOCATION = FileLocation;
            Name = name;
        }
        public Language()
        {

        }

        internal void LoadDictionary()
        {
            if (Words != null)
            {
                return;
            }
            Words = new Dictionary<string, int>();
            var lines = File.ReadLines(DICTIONARY_LOCATION);
            lines.ToList().ForEach(m => Words.Add(m.ToUpper(), CalculateVowelCount(m.ToUpper())));
        }

        internal int CalculateVowelCount(string word)
        {
            var result = 0;
            foreach (var letter in Vowels)
            {
                if (word.Any(m => m == letter))
                {
                    result++;
                }
            }
            return result;
        }

        public int GetVowelCount(string word)
        {
            LoadDictionary();
            if (Words.TryGetValue(word.ToUpper(), out int value))
            {
                return value;
            }
            else
            {
                return -1;
            }
        }

        public int GetConstantCount(string word)
        {
            return word.Length - GetVowelCount(word);
        }

        public bool DoesWordExist(string word)
        {
            LoadDictionary();
            return Words.TryGetValue(word.ToUpper(), out int value);
        }

        public List<string> GetAllWordsWithLength(int length)
        {
            LoadDictionary();
            return Words.Keys.Where(m => m.Length == length).ToList();
        }

        public List<string> GetAllWordsToLength(int length)
        {
            LoadDictionary();
            var output = new List<string>();
            var counter = 1;
            while (counter <= length)
            {
                output.AddRange(GetAllWordsWithLength(counter));
                counter++;
            }

            return output;
        }

        public List<string> GetAllPossibleWords(string characters, bool useAll = false)
        {
            LoadDictionary();

            var keys = Words.Keys.ToList();
            var secondKeys = Words.Keys.ToList();
            if (useAll)
            {
                keys = keys.Where(m => m.Length == characters.Length).ToList();
                secondKeys = keys.ToList();
            }
            var indexes = new List<int>();
            var result = new List<string>();
            var counter = 0;
            foreach (var letter in characters.ToUpper())
            {
                counter++;
                for (int i = 0; i < keys.Count(); i++)
                {

                    var lastIndex = keys[i].IndexOf(letter);
                    if (lastIndex != -1)
                    {
                        keys[i] = keys[i].Remove(lastIndex, 1);
                    }

                    if (keys[i] == "")
                    {
                        indexes.Add(i);
                        keys[i] = "🍕🍕";
                    }
                }
            }
            foreach (var i in indexes.Distinct())
            {
                result.Add(secondKeys[i]);
            }

            return result;
        }

        public int WaysToArrangeLetters(string letters)
        {

            var numOfDistinct = letters.Distinct().Count();
            var lettersRepeated = letters.Length - numOfDistinct;
            var part1 = Calculations.Factorial(numOfDistinct);
            if (lettersRepeated == 0)
            {
                return part1;
            }
            return part1 / Calculations.Factorial(lettersRepeated);
        }
    }
}
