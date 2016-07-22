namespace GSMTest
{
    using GSMClass;
    using System;

    public class GSMTest
    {
        public static void Main()
        {
            var gsms = new GSM[5];
            gsms[0] = GSM.Iphone4S;
            gsms[1] = new GSM("Lumia920", "Microsoft Corp.", new Display(4.5, 16000000), new Battery("Built-in", 500, 400, BatteryType.LiIon));
            gsms[2] = new GSM("Nexus5", "LG", 500);
            gsms[3] = new GSM("Galaxy S II", "SAMSUNG Electronics", new Display(4.7, 10000000));
            gsms[4] = new GSM("HTC 10", "High-Tech Computer Corporation", new Battery("Non-removable", 456, 27, BatteryType.LiIon));

            foreach (var gsm in gsms)
            {
                string gsmDisplay = "*NO DISPLAY CHARACTERISTICS*\r\n\r\n";
                string gsmBattery = "*NO BATTERY CHARACTERISTICS*\r\n\r\n";
                if (gsm.Display != null)
                {
                    gsmDisplay = gsm.Display.ToString();
                }

                if (gsm.Battery != null)
                {
                    gsmBattery = gsm.Battery.ToString();
                }

                Console.Write(gsm.ToString() + gsmDisplay + gsmBattery);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}