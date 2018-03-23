using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public static class FileHelper
    {
        
        private static string _path;

        public static string ReadFromPath(string path ,int docId)
        {
            var filePath = string.Format("{0}\\{1}.txt", path, docId);
            if (!File.Exists(filePath)) { return ""; }
            var fileText = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(fileText))
                throw new Exception(string.Format("System found an empty file: {0}", filePath));
            return fileText;
        }

        public static Document GetDocumentById(string _path, int documentId)
        {
            var filePath = string.Format("{0}\\{1}.txt", _path, documentId);
            if (!Directory.Exists(_path) && !File.Exists(filePath))
            {
                throw new Exception(string.Format("No Path or File is defined for reading: {0}", _path));
            }
            var fileText = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(fileText))
            {
                return null;
            }

            var splitted = fileText.Split(',');
            if (splitted.Count() < 3) { return null; }

            var docId = splitted[0].ToString();
            var country = splitted[1].ToString();

            string[] cleanSplited = new string[splitted.Length];
            Array.Copy(splitted, 2, cleanSplited, 0, (splitted.Length - 3));
            var fullText = string.Join(" ", cleanSplited);

            return  new Document(documentId, country, fullText);
        }
    }
}
