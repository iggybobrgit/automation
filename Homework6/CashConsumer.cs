namespace Homework6
{
    class CashConsumer: Consumer
    {
        public override string MakePayment()
        {
            return System.String.Format("Consumer paid by Cash");
        }
    }
}
