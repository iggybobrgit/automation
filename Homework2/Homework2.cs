using System;

namespace SecondTask
{
    class Homework2
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = index * index;
                Console.WriteLine(array[index]);
            }


        }
    }
}
