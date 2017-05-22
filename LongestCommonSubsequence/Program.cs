﻿using System;

namespace LongestCommonSubsequence
{
    internal class Program
    {
        private string LCIS(int[] a, int n, int[] b, int m)
        {
            string answer = "";
            int[] table = new int[m];
            int[] parent = new int[m];

            for (int j = 0; j < m; j++)
                table[j] = 0;

            // Traverse all elements of arr1[]
            for (int i = 0; i < n; i++)
            {
                // Initialize current length of LCIS
                int current = 0, last = -1;

                // For each element of arr1[], trvarse all
                // elements of arr2[].
                for (int j = 0; j < m; j++)
                {
                    // If both the array have same elements.
                    // Note that we don't break the loop here.
                    if (a[i] == b[j])
                    {
                        if (current + 1 > table[j])
                        {
                            table[j] = current + 1;
                            parent[j] = last;
                        }
                    }

                    /* Now seek for previous smaller common
                       element for current element of arr1 */
                    if (a[i] > b[j])
                    {
                        if (table[j] > current)
                        {
                            current = table[j];
                            last = j;
                        }
                    }
                }
            }

            // The maximum value in table[] is out result
            int result = 0, index = -1;
            for (int i = 0; i < m; i++)
            {
                if (table[i] > result)
                {
                    result = table[i];
                    index = i;
                }
            }

            // LCIS is going to store elements of LCIS
            int[] lcis = new int[result];
            for (int i = 0; index != -1; i++)
            {
                lcis[i] = b[index];
                index = parent[index];
            }

            Array.Reverse(lcis);
            answer = string.Join(",", lcis);
            return answer;
        }

        private static void Main(string[] args)
        {
            int a = 4;
            int b = 4;
            int[] arr1 = new[] { 3, 2, 7, 10 };
            int[] arr2 = new[] { 2, 7, 15, 19 };

            Program pr = new Program();
            Console.WriteLine(pr.LCIS(arr1, a, arr2, b));

            Console.ReadKey();
        }
    }
}