namespace Homework6
{
    class CashConsumer: Consumer
    {
        public override void MakePayment()
        {
            System.Console.WriteLine("Consumer with real money paid by Cash");
        }
    }
}
