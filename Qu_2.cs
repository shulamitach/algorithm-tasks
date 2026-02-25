using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Qu_2
    {
        /* *********** Logic Explanation ************
  * The structure is based on a hash table.
  * In addition, we will have a variable 'timer' that will be used as a counter.
  * In every insertion to the structure, the timer will be included with the inserted value.
  * The counter-timer will be increased by 1.
  * When operating 'setAll', we keep both the assigned value and the 'time' when setting all.
  * Then, when trying to get the value that was assigned:
  * We check if the 'setAll' was operated before inserting the value in the required key,
  * or later—then we return the 'setAll' value.
  */

        /* * Time Complexity:
         * Set/Get - Insert/get in hash table O(1) in avg.
         * SetAll - Only update variables O(1).
         */
        public class S
        {

            private struct itamInDictionary
            {
                public int val;
                public int time;
            }

            private Dictionary<int, itamInDictionary> dict = new Dictionary<int, itamInDictionary>();
            private int counter = 0;
            private int totalVal = 0;
            private int totalTime = -1;

            public void Set(int key, int val)
            {
                counter++;
                dict[key] = new itamInDictionary { val = val, time = counter };
            }

            public void SetAll(int val)
            {
                counter++;
                totalVal = val;
                totalTime = counter;
            }

            public int Get(int key)
            {

                if (!dict.TryGetValue(key, out itamInDictionary item))
                {
                    return -1;
                }

                if (item.time > totalTime)
                {
                    return item.val;
                }

                return totalVal;
            }
        }
    }
}
