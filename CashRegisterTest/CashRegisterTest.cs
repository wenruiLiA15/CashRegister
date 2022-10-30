using Moq;

namespace CashRegisterTest
{
    using CashRegister;
    using Moq;
    using Xunit;

    public class CashRegisterTest
    {
        [Fact]
        public void Should_process_execute_printing()
        {
            //given
            SpyPrinter printer = new SpyPrinter();
            var cashRegister = new CashRegister(printer);
            var stubPurchase = new StubPurchase();
            //when
            cashRegister.Process(stubPurchase);
            //then
            Assert.True(printer.HasPrinted);
            Assert.Equal("stub content", printer.PrintContent);
        }

        [Fact]
        public void Should_throw_HardwareException_when_process_given_stub_printer_throw_out_of_paper_exception()
        {
            // given
            StubPrinter printer = new StubPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
            // when
            // then
            HardwareException hardwareException = Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
            Assert.Equal("Printer is out of paper.", hardwareException.Message);
        }

        [Fact]
        public void Should_print_call_when_run_process_given_spy_printer()
        {
            // Given
            var printer = new Mock<Printer>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();
            // when
            cashRegister.Process(purchase);
            // then
            printer.Verify(_ => _.Print(It.IsAny<string>()));
        }

        [Fact]
        public void Should_print_purchase_content_when_run_process_given_stub_purchase()
        {
            // Given
            var spyPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(spyPrinter.Object);
            var stubPurchase = new Mock<Purchase>();
            stubPurchase.Setup(x => x.AsString()).Returns("moq stub content");
            // when
            cashRegister.Process(stubPurchase.Object);
            // then
            spyPrinter.Verify(_ => _.Print("moq stub content"));
        }
    }
}