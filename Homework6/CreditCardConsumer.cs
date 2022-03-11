using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class CreditCardConsumer : Consumer
    {
        public override string MakePayment()
        {
            return System.String.Format("Consumer paid by CreditCard");
        }
    }
}
