using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public static class DocumentVisitorExtension
    {
        public static string ConvertToPlainText(this Document document)
        {
            var visitor = new ConvertToPlainText();

            foreach (var part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ConvertToHtml(this Document document)
        {
            var visitor = new ConvertToHtml();

            foreach (var part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ConvertToLaTex(this Document document)
        {
            var visitor = new ConvertToLatex();

            foreach (var part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }
    }
}
