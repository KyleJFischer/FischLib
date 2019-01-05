using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FischToolsLib.Languages
{
    public class Library
    {
        Dictionary<string, Language> languages = new Dictionary<string, Language>();

        public void AddLanguage(Language lang)
        {
            languages.Add(lang.Name, lang);
        }
        public bool TryAddLanguage(Language lang)
        {
            if (!languages.ContainsKey(lang.Name)){
                AddLanguage(lang);
                return true;
            } else
            {
                return false;
            }
        }

        public bool DoesWordExistInAllLanguages(string word)
        {
            var wordToUpper = word.ToUpper();
            foreach(var lang in languages)
            {
                if (!lang.Value.DoesWordExist(wordToUpper))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DoesWordExistInAnyLanguages(string word)
        {
            var wordToUpper = word.ToUpper();
            foreach (var lang in languages)
            {
                if (lang.Value.DoesWordExist(wordToUpper))
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GetAllWordsFromScramble(string word)
        {
            var wordToUpper = word.ToUpper();
            var result = new List<string>();
            foreach (var lang in languages)
            {
                result.AddRange(lang.Value.GetAllPossibleWords(word));
            }
            return result;
        }
    }
}
