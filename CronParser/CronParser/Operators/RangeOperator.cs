using System;
using System.Collections.Generic;
using System.Linq;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;
using CronParser.Utility;

namespace CronParser.Operators
{
    public class RangeOperator : IOperator
    {
        private readonly Unit _timeUnit;

        public RangeOperator(Unit timeUnit)
        {
            _timeUnit = timeUnit;
        }

        public List<int> ApplyOperator()
        {
            // Validate if the time unit supports this operator
            if (_timeUnit.acceptedSymbols.Contains(Constants.RANGE_OPERATOR) == false)
            {
                LogError("Range operator not supported");
                return null;
            }

            // Split cron expression through '-' and parse to int
            var range = _timeUnit.cronValue.Split(Constants.RANGE_OPERATOR).Where(x => Int32.TryParse(x, out _)).Select(Int32.Parse).ToList();

            if (range.Count == 2)
            {
                // Check if range is valid
                if (range[0] < _timeUnit.minValue || range[1] > _timeUnit.maxValue)
                {
                    LogError("Range operator - Range supplied is out of bound");
                    return null;
                }

                var stringRange = RangeUtility.GetRange(range[0], range[1]);

                // If empty something wrong went with GetRange. i.e. start>end
                if (stringRange.Count == 0)
                {
                    LogError("Range operator - Wrong params supplied");
                    return null;
                }

                return stringRange;
            }
            else
            {
                LogError("Range operator - Wrong range supplied");
                return null;
            }

        }

        private void LogError(string error)
        {
            Console.WriteLine(error + " - " + _timeUnit.cronValue);
        }
    }
}
