using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class ConvertToLatex : DocumentPartVisitor
    {
        public string Line { get; private set; }

        public override string Visit(PlainText part)
            => Line += part.Text;

        public override string Visit(Hyperlink part)
            => Line += "\\href{" + part.Url + "}{" + part.Text + "}";

        public override string Visit(BoldText part)
            => Line += "\\textbf{" + part.Text + "}";
    }
}
