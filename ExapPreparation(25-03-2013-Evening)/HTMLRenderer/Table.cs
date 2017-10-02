using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class Table : Element, ITable
    {
        private IElement[,] tableMatrix;

        public Table(int rows, int cols) : 
            base("table")
        {
            this.TextContent = null;
            this.ChildElements = null;
            this.Rows = rows;
            this.Cols = cols;
            this.tableMatrix = new IElement[this.Rows, this.Cols];
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.tableMatrix[row, col];
            }

            set
            {
                this.tableMatrix[row, col] = value;
            }
        }

        public int Cols { get; }

        public int Rows { get; }

        public new IEnumerable<IElement> ChildElements { get; private set; }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>",this.Name);

            for (int row = 0; row < this.tableMatrix.GetLength(0); row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.tableMatrix.GetLength(1); col++)
                {
                    output.AppendFormat("<td>{0}</td>", this.tableMatrix[row, col]);
                }

                output.Append("</tr>");
            }

            output.AppendFormat("</{0}>", this.Name);
        }
    }
}
