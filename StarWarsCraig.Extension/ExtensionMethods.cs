using System;
using System.Linq;

namespace StarWarsCraig.Extension
{
    public static class ExtensionMethods
    {
        public static int[] Order(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int tmp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tmp;
                    }
                }
            }

            return array;
        }

        public static int[] OrderArray(this int[] array)
        {
            Array.Sort(array);
            return array;
        }

        public static int[] OrderLinq(this int[] array)
        {
            return array.OrderByDescending(x => x).ToArray();
        }
    }
}
