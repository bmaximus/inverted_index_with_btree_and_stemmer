using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BTree;
using System.Threading.Tasks;

namespace Core
{
    public class QueryParser
    {
        public QueryParser(List<string> query, Operand currentOperand)
        {
            Queries = query;
            CurrentOperand = currentOperand;
        }

        public QueryParser(string leftQuery, string rightQurry, Operand currentOperand)
        {
            LeftQuery = leftQuery ?? throw new ArgumentNullException(nameof(leftQuery));
            RightQuery = rightQurry ?? throw new ArgumentNullException(nameof(rightQurry));
            CurrentOperand = currentOperand;
        }

        public string LeftQuery { get; private set; }
        public Operand CurrentOperand { get; private set; }
        public string RightQuery { get; private set; }
        public List<string> Queries { get; private set; }

        public List<Entry<string>> ParseMultiple(ref BTree<string, List<int>> tree, string _path)
        {
            var documentsList = new List<Document>();
            var resultList = new List<Entry<string>>();
            foreach (var word in Queries)
            {
                var searchRes = tree.Search(word);
                if (!resultList.Any() && searchRes != null)
                {
                    resultList.Add(tree.Search(word));
                    continue;
                }

                if (CurrentOperand == Operand.AND && searchRes != null)
                {
                    resultList = resultList.Where(s => searchRes.Pointer.Any(a => s.Pointer.Any(b => b == a))).ToList();
                }
                if (CurrentOperand == Operand.OR && searchRes != null)
                {
                    resultList.Add(searchRes);
                }

            }


            return resultList;
        }
        /*
        public List<Document> ParseMultiple(ref BTree<string, List<int>> tree, string _path)
        {
            var documentsList = new List<Document>();
            var resultList = new List<Entry<string>>();
            foreach (var word in Queries)
            {
                var searchRes = tree.Search(word);
                if (!resultList.Any() && searchRes != null)
                {
                    resultList.Add(tree.Search(word));
                    continue;
                }

                if (CurrentOperand == Operand.AND && searchRes != null)
                {
                    resultList = resultList.Where(s => searchRes.Pointer.Any(a => s.Pointer.Any(b => b == a))).ToList();
                }
                if (CurrentOperand == Operand.OR && searchRes != null)
                {
                    resultList.Add(searchRes);
                }

            }

            foreach (var resultItem in resultList)
            {

                foreach (var documentId in resultItem.Pointer)
                {
                    var document = FileHelper.GetDocumentById(_path, documentId);

                    if (document != null)
                        documentsList.Add(document);
                }
            }

            return documentsList;
        }
        */
        public List<Document> Parse(ref BTree<string, List<int>> tree, string _path)
        {
            var documentsList = new List<Document>();
            var leftResult = tree.Search(LeftQuery);
            var rightResult = tree.Search(RightQuery);
            List<int> combinedResult = new List<int>();

            if (CurrentOperand == Operand.AND)
            {
                combinedResult = ParsingAnd(leftResult, rightResult);
            }
            else if (CurrentOperand == Operand.OR)
            {
                combinedResult = ParsingOr(leftResult, rightResult);
            }

            foreach (var documentId in combinedResult)
            {
                var document = FileHelper.GetDocumentById(_path, documentId);

                if (document != null)
                    documentsList.Add(document);
            }

            return documentsList;
        }

        private static List<int> ParsingOr(Entry<string> leftResult, Entry<string> rightResult)
        {
            List<int> combinedResult;
            if (leftResult != null && leftResult.Pointer.Any() && rightResult != null && rightResult.Pointer.Any())
            {
                combinedResult = leftResult.Pointer.Union(rightResult.Pointer).Select(s => s).ToList();

            }
            else if (leftResult == null && rightResult != null)
                combinedResult = rightResult.Pointer;
            else if (rightResult == null && leftResult != null)
                combinedResult = leftResult.Pointer;
            else
                combinedResult = new List<int>();
            return combinedResult;
        }
        private static List<int> ParsingAnd(Entry<string> leftResult, Entry<string> rightResult)
        {
            List<int> combinedResult;
            if (leftResult != null && leftResult.Pointer.Any() && rightResult != null && rightResult.Pointer.Any())
            {
                if (leftResult.Pointer.Count < rightResult.Pointer.Count)
                    combinedResult = leftResult.Pointer.Where(l => rightResult.Pointer.Any(r => l == r)).ToList();
                else
                    combinedResult = rightResult.Pointer.Where(r => leftResult.Pointer.Any(l => l == r)).ToList();
            }
            else if (leftResult == null && rightResult != null)
                combinedResult = rightResult.Pointer;
            else if (rightResult == null && leftResult != null)
                combinedResult = leftResult.Pointer;
            else
                combinedResult = new List<int>();
            return combinedResult;
        }
        
    }
}
