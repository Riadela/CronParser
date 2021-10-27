using System;
using System.Collections.Generic;
using System.Linq;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;

namespace CronParser.Operators
{
    public class CommaOperator : IOperator
    {
        private readonly Unit _timeUnit;
        public CommaOperator(Unit timeUnit)
        {
            _timeUnit = timeUnit;
        }

        public List<int> ApplyOperator()
        {
            // Validate if the time unit supports this operator
            if (_timeUnit.acceptedSymbols.Contains(Constants.COMMA_OPERATOR) == false)
            {
                LogError("Comma operator not supported");
                return null;
            }

            // Split cron expression through ',' and try to parse to int
            var stringValues = _timeUnit.cronValue.Split(Constants.COMMA_OPERATOR);
            var listValues = stringValues.Where(x => Int32.TryParse(x, out _)).Select(int.Parse).ToList();

            // If size is different, it means it couldn't parse one of the values to int
            if (stringValues.Length != listValues.Count)
            {
                LogError("Comma operator - One of the args is not a valid int");
                return null;
            }

            // Validate expression
            if (ValidateCommaExpression(listValues))
            {
                return listValues;
            }

            return null;

        }

        private bool ValidateCommaExpression(List<int> listValues)
        {
            // Check if list is empty
            if (!listValues.Any())
            {
                LogError("Comma operator - Returned empty list");
                return false;
            }

            // Validate each parameter supplied in the list
            foreach (var cronValue in listValues)
            {
                if (cronValue > _timeUnit.maxValue || cronValue < _timeUnit.minValue)
                {
                    LogError("Range operator - One of the params supplied is not valid");
                    return false;
                }
            }

            return true;
        }

        private void LogError(string error)
        {
            Console.WriteLine(error + " - " + _timeUnit);
        }
    }
}
