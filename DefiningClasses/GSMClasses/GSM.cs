namespace GSMClasses
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        // fields
        private static GSM iphone4S = new GSM("Iphone 4S", "Apple Inc.", new Display(3.5, 16000000), new Battery("Built-in", 400, 100, BatteryType.LiPol));

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Display display;
        private Battery battery;
        private List<Call> callHistory = new List<Call>();

        // constructors
        public GSM(string _model, string _manufacturer)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = 0m;
            this.Owner = "N/A";
            this.Display = null;
            this.Battery = null;
        }

        public GSM(string _model, string _manufacturer, decimal _price)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = _price;
            this.Owner = "N/A";
            this.Display = null;
            this.Battery = null;
        }

        public GSM(string _model, string _manufacturer, decimal _price, string _owner)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = _price;
            this.Owner = _owner;
            this.Display = null;
            this.Battery = null;
        }

        public GSM(string _model, string _manufacturer, Display _display)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = 0;
            this.Owner = "N/A";
            this.Display = _display;
            this.Battery = null;
        }

        public GSM(string _model, string _manufacturer, Battery _battery)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = 0;
            this.Owner = "N/A";
            this.Display = null;
            this.Battery = _battery;
        }

        public GSM(string _model, string _manufacturer, Display _display, Battery _battery)
        {
            this.Model = _model;
            this.Manufacturer = _manufacturer;
            this.Price = 0;
            this.Owner = "N/A";
            this.Display = _display;
            this.Battery = _battery;
        }

        // properties
        public static GSM Iphone4S
        {
            get
            {
                return iphone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value != string.Empty && value != null)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("model cannot be empty");
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (value != string.Empty && value != null)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("manufacturer cannot be empty");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price cannot be negative");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            set
            {
                this.display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                this.battery = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = value;
            }
        }

        // methods
        public override string ToString()
        {
            string summary = "*GSM*\r\nModel: {0},\r\nManufacturer: {1},\r\nPrice: {2},\r\nOwner: {3}\r\n\r\n";
            string description = string.Format(summary, this.Model, this.Manufacturer, this.Price, this.Owner);
            return description;
        }

        public void AddCall(Call lastCall)
        {
            this.CallHistory.Add(lastCall);
        }

        public void DeleteCall(Call someCall)
        {
            this.CallHistory.Remove(someCall);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculateTotalPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0m;

            // validate price
            if (pricePerMinute < 0)
            {
                throw new ArgumentOutOfRangeException("price cannot be negative");
            }

            foreach (var call in this.CallHistory)
            {
                // converts call in minutes
                totalPrice += (call.Duration / 60.0m) * pricePerMinute;
            }

            return totalPrice;
        }
    }
}