using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class Element : IElement
    {
        private List<IElement> childElements;

        public Element(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public Element(string name, string content)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public virtual IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public string Name { get; }

        public string TextContent { get; set; }

        public void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);

                output.AppendFormat(
                    "{0}{1}",
                    this.TextContent == null ? this.TextContent : EncodeHTML(this.TextContent),
                    string.Join("", this.ChildElements));

                output.AppendFormat("</{0}>", this.Name);
            }
            else
            {
                output.AppendFormat(
                    "{0}{1}",
                    this.TextContent == null ? this.TextContent : EncodeHTML(this.TextContent),
                    string.Join("", this.ChildElements));
            }


        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);

            return output.ToString();
        }

        private string EncodeHTML(string textContent)
        {
            return textContent.
                Replace("&", "&amp;").
                Replace("<", "&lt;").
                Replace(">", "&gt;");
        }
    }
}
