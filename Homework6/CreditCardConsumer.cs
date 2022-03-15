using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class CreditCardConsumer : Consumer
    {
        public override void MakePayment()
        {
            Console.WriteLine ("Consumer with credit card paid by CreditCard");
        }
    }
}
