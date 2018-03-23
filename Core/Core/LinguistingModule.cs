using Porter2Stemmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public static class LinguisticModule
    {
        private static EnglishPorter2Stemmer _stemmer = new EnglishPorter2Stemmer();

        

        public static List<string> Tokenize(string fileText)
        {
            if (string.IsNullOrWhiteSpace(fileText))
            {
                return new List<string>();
            }

            var splitted = fileText.Split(',');
            if (splitted.Count() < 3) { return new List<string>(); }

            var docId = splitted[0].ToString();
            var country = splitted[1].ToString();

            var stringList = new List<string>();

            string[] cleanSplited = new string[splitted.Length];
            Array.Copy(splitted, 2, cleanSplited, 0, (splitted.Length - 3));
            var fullText = string.Join(" ", cleanSplited).ToLower().Replace("\"", "").Replace(".", "").Replace(",", "");

            List<string> text = new List<string>();
            text.AddRange(fullText.Split(' '));
            return text;
        }
        
        public static string Stem(string word)
        {
            return _stemmer.Stem(word).Value;
        }


        public static List<string> Stemming(List<string> text)
        {
            if (!text.Any()) { return new List<string>(); }
                        
            var returnList = new List<string>();

            returnList.AddRange(text.Where(s => !string.IsNullOrWhiteSpace(s)).Select(a => Stem(a)));

            return returnList;
           
        }
    }
}
