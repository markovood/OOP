using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Exceptions;

namespace FastAndFurious.ConsoleApplication.Common.Utils
{
    public static class Validator
    {
        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateCollectionIDs(IEnumerable<IIdentifiable> collection, IIdentifiable obj, string message, string firstParameterName = "", string secondParameterName = "")
        {
            if (collection.Any(x => x.Id == obj.Id))
            {
                throw new InvalidOperationException(string.Format(message, firstParameterName, secondParameterName));
            }
        }

        public static void ValidateTypeDuplication(IEnumerable<IIdentifiable> collection, IIdentifiable obj, string message, string paramName)
        {
            if (collection.Any(x => x.GetType().Name == obj.GetType().Name))
            {
                throw new TunningDuplicationException(message, paramName);
            }
        }
    }
}
