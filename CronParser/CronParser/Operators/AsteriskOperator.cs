using System;
using System.Collections.Generic;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;
using CronParser.Utility;

namespace CronParser.Operators
{
    public class AsteriskOperator : IOperator
    {
        private readonly Unit _timeUnit;
        public AsteriskOperator(Unit timeUnit)
        {
            _timeUnit = timeUnit;
        }

        public List<int> ApplyOperator()
        {
            // Validate if the time unit supports this operator
            if (_timeUnit.acceptedSymbols.Contains(Constants.ASTERISK_OPERATOR) == false)
            {
                LogError("Asterisk operator not supported");
                return null;
            }

            var range = RangeUtility.GetRange(_timeUnit.minValue, _timeUnit.maxValue);
            if (range.Count == 0)
            {
                LogError("Asterisk operator - Failed to get range");
                return null;
            }

            return range;
        }

        private void LogError(string error)
        {
            Console.WriteLine(error + " - " + _timeUnit.cronValue);
        }
    }
}
