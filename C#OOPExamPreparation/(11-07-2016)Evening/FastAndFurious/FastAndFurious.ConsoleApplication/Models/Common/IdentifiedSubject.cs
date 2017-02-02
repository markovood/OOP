using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Utils;

namespace FastAndFurious.ConsoleApplication.Models.Common
{
    public class IdentifiedSubject : IIdentifiable
    {
        private int id;

        public IdentifiedSubject()
        {
            this.id = DataGenerator.GenerateId();
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }
    }
}
