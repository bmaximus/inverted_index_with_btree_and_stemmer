namespace BTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Entry<TK> : IEquatable<Entry<TK>>
    {
        public TK Key { get; set; }

        public List<int> Pointer { get; set; }
        //public void Combine( TP newPointer)
        //{
        //    var oldPointers = (this.Pointer as int[]).ToList();
        //    var newPointers = (newPointer as int[]).ToList();

        //    if (typeof(TP) == typeof(int[]))
        //    {
        //        int[] t =  (Pointer as int[]);
        //        t = oldPointers.Union(newPointers).OrderBy(a => a).ToArray();
        //    }       



           

        //}

        public bool Equals(Entry<TK> other)
        {
            return this.Key.Equals(other.Key) && this.Pointer.Equals(other.Pointer);
        }

        public override string ToString()
        {
            return string.Format("Key: {0}   Pointer: {1}", this.Key, string.Join(",", (this.Pointer)));
        }
    }
}
