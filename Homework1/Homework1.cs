using System;

namespace FirstTask
{
    class Homework1
    {
        static void Main(string[] args)
        {
            byte maxByteValue = byte.MaxValue;
            byte minByteValue = byte.MinValue;
            short maxShortValue = short.MaxValue;
            short minShortValue = short.MinValue;
            int maxIntValue = int.MaxValue;
            int minIntValue = int.MinValue;
            long maxLongValue = long.MaxValue;
            long minLongValue = long.MinValue;
            float maxFloatValue = float.MaxValue;
            float minFloatValue = float.MinValue;
            double maxDoubleValue = double.MaxValue;
            double minDoubleValue = double.MinValue;
            uint maxUintValue = uint.MaxValue;
            uint minUintValue = uint.MinValue;
            ulong maxUlongValue = ulong.MaxValue;
            ulong minUlongValue = ulong.MinValue;



            Console.WriteLine("Max value for byte is {0} ", maxByteValue);
            Console.WriteLine("Min value for byte is {0} ", minByteValue);

            Console.WriteLine("Max value for short is {0} ", maxShortValue);
            Console.WriteLine("Min value for short is {0} ", minShortValue);

            Console.WriteLine("Max value for int is {0} ", maxIntValue);
            Console.WriteLine("Min value for int is {0} ", minIntValue);

            Console.WriteLine("Max value for long is {0} ", maxLongValue);
            Console.WriteLine("Min value for long is {0} ", minLongValue);

            Console.WriteLine("Max value for float is {0} ", maxFloatValue);
            Console.WriteLine("Min value for float is {0} ", minFloatValue);

            Console.WriteLine("Max value for double is {0} ", maxDoubleValue);
            Console.WriteLine("Min value for double is {0} ", minDoubleValue);

            Console.WriteLine("Max value for uint is {0} ", maxUintValue);
            Console.WriteLine("Min value for uint is {0} ", minUintValue);

            Console.WriteLine("Max value for ulong is {0} ", maxUlongValue);
            Console.WriteLine("Min value for ulong is {0} ", minUlongValue);
        }
    }
}
