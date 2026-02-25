using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Qu_3
    {
        /*recurtion*/
        static int GetMaxSequence(Node current, int lastValue)
        {
            if (current == null) return 0;

            int withoutCurrent = GetMaxSequence(current.Next, lastValue);

            int withCurrent = 0;
            if (current.Value >= lastValue)
            {
                withCurrent = 1 + GetMaxSequence(current.Next, current.Value);
            }

            return Math.Max(withoutCurrent, withCurrent);
        }

        /* Dynamic Programming /
        / The time complexity of the recursive solution is 2^n.
        In order to improve it, we use Dynamic Programming like this:
        We use an array to store the previous results,
        and then in subsequent nodes we rely on them.
        Every index i in the DP array represents a sub-problem ,
        of the Longest Non-Decreasing Subsequence that ends at index i.
        */
        static int[] ListToArray(Node head)
        {
            List<int> tempList = new List<int>();
            Node current = head;
            while (current != null)
            {
                tempList.Add(current.Value);
                current = current.Next;
            }
            return tempList.ToArray();
        }
        static int MaxNonDecreasingList(Node head)
        {
            if (head == null) return 0;

            int[] arr = ListToArray(head);
            int n = arr.Length;

            int[] dp = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] <= arr[i] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                    }
                }
            }

            int maxRezef = 0;
            for (int i = 0; i < n; i++)
            {
                if (dp[i] > maxRezef) maxRezef = dp[i];
            }

            return n - maxRezef;//that means the nodes we droped-the min that possoble.
        }
        /***********time complexity: o(n ^ 2) * *******
        /*node class(additional to this answer)*/
        public class Node
        {
            public int Value;
            public Node Next;
            public Node(int val) { Value = val; Next = null; }
        }
    }
}
