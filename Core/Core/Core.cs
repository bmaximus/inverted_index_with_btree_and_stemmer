using BTree;
using Porter2Stemmer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class InvertedIndex
    {
        public InvertedIndex()
        {
            CreateInvertedIndex();
        }

        public string Path { get; private set; } = @"C:\Dionysos\";

        private BTree<string, List<int>> _tree = new BTree<string, List<int>>(10);

        private void CreateInvertedIndex()
        {
            if (!Directory.Exists(Path))
            {
                throw new Exception(string.Format("No Path is defined for reading: {0}", Path));
            }
            var folderFiledCount = Directory.GetFiles(Path).Length;
            var step = folderFiledCount / 10;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var taskBucket = new List<Task>();
            for (int i = 0; i < folderFiledCount; i = i + step)
            {
                var upperLimit = i + step;
                if (upperLimit > folderFiledCount)
                {
                    upperLimit = folderFiledCount - 1;
                }
                taskBucket.Add(Task.Factory.StartNew(() => ReadFilesWorker(i, upperLimit)));
                Task.WaitAll(taskBucket.ToArray());
            }
            stopWatch.Stop();
            var timeElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds / 10); ;
            GC.Collect();



            Trace.WriteLine(timeElapsed);


        }

        private void ReadFilesWorker(int from, int to)
        {
            for (int docId = from; docId < to; docId++)
            {
                string fileText = FileHelper.ReadFromPath(Path, docId);

                var stemmedList = LinguisticModule.Stemming(LinguisticModule.Tokenize(fileText));

                foreach (var word in stemmedList)
                {
                    Task.Factory.StartNew(() => WriteStemmedToTree(docId, word));
                }
            }
        }

        private void WriteStemmedToTree(int docId, string stemmed)
        {
            lock (_tree)
            {
                _tree.Insert(stemmed, new List<int>() { docId });
            }
        }

        public List<Document> GetResults(string text)
        {

            var splitted = text.Split(' ');
            var firstWord = "";
            var secondWord = "";
            var lastOperand = "OR";
            foreach (var word in splitted)
            {
                if (string.IsNullOrWhiteSpace(firstWord))
                {
                    firstWord = LinguisticModule.Stem(word);
                    continue;
                }
                Operand operand;
                var tryParse = Enum.TryParse(word.ToUpper(), true, out operand);
                if (tryParse)
                {
                    lastOperand = word.ToUpper();
                    continue;
                }
                if (string.IsNullOrWhiteSpace(secondWord))
                {
                    secondWord = LinguisticModule.Stem(word);
                    continue;
                }
            }


            var qp = new QueryParser(firstWord, secondWord, (Operand)Enum.Parse(typeof(Operand), lastOperand.ToString()));
            return qp.Parse(ref _tree, Path);
        }
    }
}
