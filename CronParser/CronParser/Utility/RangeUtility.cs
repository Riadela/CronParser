using System;
using System.Collections.Generic;

namespace CronParser.Utility
{
    public class RangeUtility
    {
        public static List<int> GetRange(int start, int end)
        {
            List<int> listRange = new List<int>();

            if (start > end)
            {
                Console.WriteLine("GetRange - start is smaller than end");
                return listRange;
            }

            for (int i = start; i <= end; i++) { listRange.Add(i); }

            return listRange;
        }
    }
}
