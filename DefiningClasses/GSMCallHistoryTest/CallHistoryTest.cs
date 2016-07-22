namespace GSMCallHistoryTest
{
    using GSMClass;
    using System;

    // Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
    public class CallHistoryTest
    {
        public static void Main()
        {
            // 1.Create an instance of the GSM class.
            var gsm = new GSM("Nexus5", "LG", 500);

            // 2.Add few calls.
            var call1 = new Call("0893484096", DateTime.Now.Date, DateTime.Now.TimeOfDay, 30);
            var call2 = new Call("0878755666", DateTime.Now.Date, DateTime.Now.TimeOfDay, 45);
            var call3 = new Call("0893893893", DateTime.Now.Date, DateTime.Now.TimeOfDay, 6);
            var call4 = new Call("0888088088", DateTime.Now.Date, DateTime.Now.TimeOfDay, 10);
            var call5 = new Call("64976779", DateTime.Now.Date, DateTime.Now.TimeOfDay, 3);

            gsm.AddCall(call1);
            gsm.AddCall(call2);
            gsm.AddCall(call3);
            gsm.AddCall(call4);
            gsm.AddCall(call5);

            // 3.Display the information about the calls.
            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }

            // 4.Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            decimal pricePerMinute = 0.37m;
            decimal callHistoryCost = gsm.CalculateTotalPrice(pricePerMinute);
            Console.WriteLine("Total cost of all calls in history is: {0:F2}", callHistoryCost);

            // 5.Remove the longest call from the history and calculate the total price again.
            int longestDuration = 0;
            Call longestCall = null;
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                if (gsm.CallHistory[i].Duration > longestDuration)
                {
                    longestDuration = gsm.CallHistory[i].Duration;
                    longestCall = gsm.CallHistory[i];
                }
            }

            gsm.DeleteCall(longestCall);
            callHistoryCost = gsm.CalculateTotalPrice(pricePerMinute);

            // 6.Finally clear the call history and print it.
            gsm.ClearCallHistory();
            if (gsm.CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
            }
            else
            {
                foreach (var call in gsm.CallHistory)
                {
                    Console.WriteLine(call);
                }
            }
        }
    }
}