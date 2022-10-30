namespace CashRegister
{
    public class SpyPrinter : Printer
    {
        public string PrintContent { get; set; }
        public bool HasPrinted { get; set; }
        public override void Print(string content)
        {
            PrintContent = content;
            // send message to a real printer
            base.Print(content);
            HasPrinted = true;
        }
    }
}