namespace BTree
{
    using System.Collections.Generic;
    using System.Text;
    public class Node<TK, TP> where TP :List<int>
    {
        private int degree;

        public Node(int degree)
        {
            this.degree = degree;
            this.Children = new List<Node<TK, TP>>(degree);
            this.Entries = new List<Entry<TK>>(degree);
        }

        public List<Node<TK, TP>> Children { get; set; }

        public List<Entry<TK>> Entries { get; set; }

        public bool IsLeaf
        {
            get
            {
                return this.Children.Count == 0;
            }
        }

        public bool HasReachedMaxEntries
        {
            get
            {
                return this.Entries.Count == (2 * this.degree) - 1;
            }
        }

        public bool HasReachedMinEntries
        {
            get
            {
                return this.Entries.Count == this.degree - 1;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var entry in Entries)
            {
                sb.AppendLine(string.Format("Entry: {0}", entry.ToString()));

            }

            foreach (var child in Children)
            {
                sb.AppendLine(string.Format("Child: {0}", child.ToString()));

            }

           



            return sb.ToString();
        }
    }
}
