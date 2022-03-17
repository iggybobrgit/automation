using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class DebtCardConsumer:Consumer
    {
        public override void MakePayment()
        {
            Console.WriteLine("Consumer with debit card paid by DebitCard");
        }
    }
}
