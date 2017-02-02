using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Contracts;
using Dealership.Common;
using Dealership.Models.ConstantsExtended;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
            // set initial value to author
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author cannot be NULL or EMPTY!");
                }

                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                Validator.ValidateNull(
                    value,
                    Constants.CommentCannotBeNull);
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCommentLength,
                    Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,ExtendedConstants.parameterContent, Constants.MinCommentLength, Constants.MaxCommentLength));

                this.content = value;
            }
        }

        public override string ToString()
        {
            StringBuilder printout = new StringBuilder();

            printout.AppendLine("    " + new string('-', 10));
            printout.AppendFormat("    {0}", this.Content).AppendLine();
            printout.AppendFormat("      User: {0}", this.Author).AppendLine();
            printout.Append("    " + new string('-', 10));

            return printout.ToString();
        }
    }
}
