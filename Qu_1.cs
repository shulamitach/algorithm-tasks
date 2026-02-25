using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Qu_1
    {
        static int FindMaxSubArrRec(int[] arr, int maxSoFar, int currentMax, int n, int i)
        {
            if (n == 0)
                return 0;
            if (i == n)
                return maxSoFar;
            int newCyrrentMax = Math.Max(arr[i], currentMax + arr[i]);
            int newMaxSoFar = Math.Max(maxSoFar, newCyrrentMax);

            return FindMaxSubArrRec(arr, newMaxSoFar, newCyrrentMax, n, i + 1);
        }
        static int FindMaxSubArr(int[] arr)
        {
            int result = FindMaxSubArrRec(arr, arr[0], arr[0], arr.Length, 1);
            return result;
        }
    
      
    }
}
