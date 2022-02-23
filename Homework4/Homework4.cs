using System;

namespace Homework_4
{

    class Homework4
    {

        static int Maximum(int[] array)
        {
            int maxValue = array[0];
            int maxPosition = 0;

            for (int index = 0; index < array.Length; index++)
            {
                if (maxValue < array[index])
                {
                    maxValue = array[index];
                    maxPosition = index;
                }
            }
            return maxPosition;

        }

        static int Minimum(int[] array)
        {
            int minValue = array[0];
            int minPosition = 0;

            for (int index = 0; index < array.Length; index++)
            {
                if (minValue > array[index])
                {
                    minValue = array[index];
                    minPosition = index;
                }
            }
            return minPosition;
        }


        static int[] Change(int[] array, int minPosition, int maxPosition)
        {
            int temp;
            temp = array[minPosition];
            array[minPosition] = array[maxPosition];
            array[maxPosition] = temp;
            return array;
        }



        static void Main(string[] args)
        {

            int[] mainArray = new int[] { 10, 31, -5, 99, 1, 43, 19, -55, 9, 2 };
            int[] mainArray1 = new int[] { 23, 144, -921, 9, 1, 4, 89, 55, 229, 2 };

            int maxPosition = Maximum(mainArray), minPosition = Minimum(mainArray), maxPosition1 = Maximum(mainArray1), minPosition1 = Minimum(mainArray1);


            Console.WriteLine("Max value in first array is {0} , position in array is {1} ", mainArray[maxPosition], maxPosition);
            Console.WriteLine("Min value in first array is {0} , position in array is {1} ", mainArray[minPosition], minPosition);
            Console.WriteLine("Max value in 2nd array is {0} , position in array is {1} ", mainArray1[maxPosition1], maxPosition1);
            Console.WriteLine("Min value in 2nd array is {0} , position in array is {1} ", mainArray1[minPosition1], minPosition1);


            Change(mainArray, maxPosition, minPosition);
            Change(mainArray1, maxPosition1, minPosition1);

            Console.Write("First array with changed min and max values: ");
            for (int index = 0; index < mainArray.Length; index++)
            {

                Console.Write("{0} ", mainArray[index]);

            }
            Console.WriteLine();
            Console.Write("2nd array with changed min and max values: ");
            for (int index = 0; index < mainArray1.Length; index++)
            {

                Console.Write("{0} ", mainArray1[index]);

            }

        }
    }
}
