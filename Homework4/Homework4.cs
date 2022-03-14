using System;

namespace Homework_4
{

    class Homework4
    {
        static int[] GetMaxMin(int[] array)
        {
            int maxValue = array[0];
            int minValue = array[0];
            int[] minmaxPosition = new int[2];

            for (int index = 0; index < array.Length; index++)
            {
                if (maxValue < array[index])
                {
                    maxValue = array[index];
                    minmaxPosition[1] = index;
                }
                if (minValue > array[index])
                {
                    minValue = array[index];
                    minmaxPosition[0] = index;
                }
            }
            return minmaxPosition;

        }
         static void Change(int[] array, int[] minmaxArray)
        {
            int temp;
            temp = array[minmaxArray[0]];
            array[minmaxArray[0]] = array[minmaxArray[1]];
            array[minmaxArray[1]] = temp;
        }

        static void PrintChangedArray(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] mainArray = new int[] { 10, 31, -5, 99, 1, 43, 19, -55, 9, 2 };
            int[] mainArray1 = new int[] { 23, 144, -921, 9, 1, 4, 89, 55, 229, 2 };

            var minmaxPositionArray = GetMaxMin(mainArray);
            var minmaxPositionArray1 = GetMaxMin(mainArray1);

            Console.WriteLine("Max value in first array is {0}, position in array is {1} ", mainArray[minmaxPositionArray[1]], minmaxPositionArray[1]);
            Console.WriteLine("Min value in first array is {0}, position in array is {1} ", mainArray[minmaxPositionArray[0]], minmaxPositionArray[0]);
            Console.WriteLine("Max value in 2nd array is {0}, position in array is {1} ", mainArray1[minmaxPositionArray1[1]], minmaxPositionArray1[1]);
            Console.WriteLine("Min value in 2nd array is {0}, position in array is {1} ", mainArray1[minmaxPositionArray1[0]], minmaxPositionArray1[0]);

            Change(mainArray, minmaxPositionArray);
            Change(mainArray1, minmaxPositionArray1);

            Console.WriteLine("First array with changed values:");
            PrintChangedArray(mainArray);
            Console.WriteLine("Second array with changed values:");
            PrintChangedArray(mainArray1);
        }
    }
}
