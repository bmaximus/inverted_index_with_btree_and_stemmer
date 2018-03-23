using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Document
    {
        public Document(int documentId, string country, string internalText)
        {
            DocumentId = documentId;
            Country = country ?? throw new ArgumentNullException(nameof(country));
            InternalText = internalText ?? throw new ArgumentNullException(nameof(internalText));
        }

        public int DocumentId { get; private set; }
        public string Country { get; private set; }
        public string InternalText { get; private set; }


        public override string ToString()
        {
            return string.Format("Document Id:{0} Country: {1} {2} Text: {3}", 
                                  DocumentId, Country, Environment.NewLine, InternalText);
        }
    }
}
