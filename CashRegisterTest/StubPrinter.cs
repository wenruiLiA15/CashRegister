using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister;

namespace CashRegisterTest
{
    internal class StubPrinter : Printer
    {
        public override void Print(string content)
        {
            throw new PrinterOutOfPaperException();
        }
    }
}
