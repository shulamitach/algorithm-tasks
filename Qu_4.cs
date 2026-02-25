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

            return count;
        }
    }
}
