using System;

namespace CashRegister
{
    public class StubPurchase : Purchase
    {
        public override string AsString()
        {
            return "stub content";
        }

        private string Timestamp()
        {
            return DateTime.Now.ToString("fff");
        }
    }
}