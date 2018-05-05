using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public abstract class DocumentPartVisitor
    {
        public void DynamicVisit(DocumentPart part)
            => Visit((dynamic)part);

        public abstract string Visit(PlainText part);

        public abstract string Visit(Hyperlink part);

        public abstract string Visit(BoldText part);
    }
}
