using System;
using System.Collections.Generic;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;

namespace CronParser.Operators
{
    public class ValueOperator : IOperator
    {
        private readonly Unit _timeUnit;

        public ValueOperator(Unit timeUnit)
        {
            _timeUnit = timeUnit;
        }

        public List<int> ApplyOperator()
        {
            int value;

            if (Int32.TryParse(_timeUnit.cronValue, out value) == false)
            {
                LogError("Value operator - Couldn't parse to int");
                return null;
            }

            if (value < _timeUnit.minValue || value > _timeUnit.maxValue)
            {
                LogError("Value operator - Value out of range");
                return null;
            }

            return new List<int>() { value };
        }

        private void LogError(string error)
        {
            Console.WriteLine(error + " - " + _timeUnit.cronValue);
        }
    }
}
