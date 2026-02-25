using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Qu_4
    {
        static int CountSubarrays(int[] arr, int X)
        {
            Dictionary<int, int> timeOfSum = new Dictionary<int, int>();

            int currentSum = 0, count = 0;

            timeOfSum[0] = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];

                int dif = currentSum - X;

                if (timeOfSum.ContainsKey(dif))
                {
                    count += timeOfSum[dif];
                }

                if (timeOfSum.ContainsKey(currentSum))
                {
                    timeOfSum[currentSum]++;
                }
                else
                {
                    // פעם ראשונה שרואים את הסכום הזה
                    timeOfSum[currentSum] = 1;
                }
            }
             /*explaintion:
            we go on the whole array,
            in each iteration' the current sum can be:
            1.equal:we found more sub array that equal to x.
            2.lower- than we continue..
            3.bigger than we try to find in the hash table:
            if we find that the difference between currentsum and x was also reached before.
            that means we can drop those pieces of array and get exatally x,
            the number of times that the diference was reached.*/
            return count;
        }
    }
}
