using System;

namespace Homework3
{
    class Homework3
    {

        static void InitializeArray(int[] array, int degree)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                for (int k = 0; k < (degree - 1); k++)
                {
                    array[i] = array[i] * i;
                }
            }
        }

        static float AverValue(int[] array)
        {
            float aver = 0;
            float sum = 0;

            for (int i = 0; i < array.Length; i++)
            {

                sum += array[i];
            }

            aver = sum / array.Length;
            return aver;

        }
        static void Main(string[] args)
        {
            int[] indexArray = new int[10];
            InitializeArray(indexArray, 1);
            Console.WriteLine(AverValue(indexArray));


            int[] squareArray = new int[10];
            InitializeArray(squareArray, 2);
            Console.WriteLine(AverValue(squareArray));

            int[] cubeArray = new int[10];
            InitializeArray(cubeArray, 3);
            Console.WriteLine(AverValue(cubeArray));
        }
    }
}
