using System;

namespace Homework6
{
    class Homework6
    {
        static void Main(string[] args)
        {
            Consumer consumer1 = new CashConsumer();
            Consumer consumer2 = new CashConsumer();
            Consumer consumer3 = new CreditCardConsumer();
            Consumer consumer4 = new DebtCardConsumer();
            Consumer consumer5 = new DebtCardConsumer();

            Consumer[] Customers = { consumer1, consumer2, consumer3, consumer4, consumer5 };

            foreach (Consumer item in Customers)
            {
                item.MakePayment();
            }
        }
    }
}
