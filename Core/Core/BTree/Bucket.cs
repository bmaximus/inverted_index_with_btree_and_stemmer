using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    public class Bucket
    {
        public Bucket()
        {
            DocIds = new List<int>(); 
        }
        public List<int> DocIds { get; set; }

        public override string ToString()
        {           
            return string.Format("DocIds : {0}", string.Join(",", DocIds));
        }

    }
}
