using System;
using System.Collections.Generic;

namespace CronParser.Pocos
{
    public class Unit
    {
        public int minValue { get; }
        public int maxValue { get; }
        public HashSet<char> acceptedSymbols { get; }
        public string cronValue { get; }

        public Unit(int minValue, int maxValue, string cronValue, HashSet<char> acceptedSymbols)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.acceptedSymbols = acceptedSymbols;
            this.cronValue = cronValue;
        }
    }
}
