using System;

namespace Homework3
{
    class Homework3
    {

        static double[] InitializeArray(int arrayLenght, int degree)
        {
            double[] array = new double[arrayLenght];

            for (int i = 0; i < array.Length; i++)
            {
               array[i] = i;
               array[i] = Math.Pow(array[i], degree);
            }
           
            return array;
        }

        static double AverValue(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return  sum / array.Length;
        }
        static void Main(string[] args)
        {
            
            double[] indexArray = InitializeArray(10, 1);
            Console.WriteLine(AverValue(indexArray));
         
            indexArray = InitializeArray(10, 2);
            Console.WriteLine(AverValue(indexArray));

            indexArray = InitializeArray(10, 3);
            Console.WriteLine(AverValue(indexArray));
        }
    }
}
