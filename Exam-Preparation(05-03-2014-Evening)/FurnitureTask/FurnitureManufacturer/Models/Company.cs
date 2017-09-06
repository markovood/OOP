namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("name", "Cannot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Cannot set an empty string for 'Name' property!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name of company cannot be less than 5 characters!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            set
            {
                if (!(this.IsExactlyTenChars(value) && this.IsOnlyDigits(value)))
                {
                    throw new ArgumentException("Registration number must be exactly 10 digits!");
                }

                // add check for null if necessary
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder catalogEntries = new StringBuilder();

            var furnituresOrdered = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();

            catalogEntries.AppendFormat(
                                "{0} - {1} - {2} {3}",
                                this.Name,
                                this.RegistrationNumber,
                                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            if (furnituresOrdered.Count > 0)
            {
                catalogEntries.AppendLine();

                for (int i = 0; i < furnituresOrdered.Count; i++)
                {
                    if (i == furnituresOrdered.Count - 1)
                    {
                        catalogEntries.Append(furnituresOrdered[i].ToString());
                    }
                    else
                    {
                        catalogEntries.AppendLine(furnituresOrdered[i].ToString());
                    }
                }
            }

            return catalogEntries.ToString();
        }

        public IFurniture Find(string model)
        {
            IFurniture furniture = this.furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());

            return furniture;
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        private bool IsOnlyDigits(string value)
        {
            foreach (var symbol in value)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsExactlyTenChars(string value)
        {
            if (value.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
