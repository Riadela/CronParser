using System;
using System.Collections.Generic;
using System.Linq;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;

namespace CronParser.Operators
{
    public class SlashOperator : IOperator
    {
        private readonly Unit _timeUnit;
        private readonly IOperatorDelegator _operatorDelegator;
        private readonly HashSet<char> slashAcceptedSymbols = new HashSet<char>() { Constants.RANGE_OPERATOR, Constants.ASTERISK_OPERATOR };

        public SlashOperator(Unit timeUnit, IOperatorDelegator operatorDelegator)
        {
            _timeUnit = timeUnit;
            _operatorDelegator = operatorDelegator;
        }

        public List<int> ApplyOperator()
        {
            // Validate if the time unit supports this operator
            if (_timeUnit.acceptedSymbols.Contains(Constants.SLASH_OPERATOR) == false)
            {
                LogError("Slash operator not supported");
                return null;
            }

            var expression = _timeUnit.cronValue.Split(Constants.SLASH_OPERATOR);

            if (expression.Length == 2)
            {
                // Check if left expression is just a digit. i.e. 12/x => 12
                // If so, create a range expression. i.e. 12-maxValue 
                if (expression[0].All(char.IsDigit))
                    expression[0] = expression[0] + Constants.RANGE_OPERATOR + _timeUnit.maxValue.ToString();

                // Delegate the left expression to be calculated, with accepted symbols only - and *
                Unit unitLeftExp = new Unit(_timeUnit.minValue, _timeUnit.maxValue, expression[0], slashAcceptedSymbols);
                var leftExpression = _operatorDelegator.OperatorDelegate(unitLeftExp).ApplyOperator();

                if (leftExpression == null || leftExpression.Count == 0)
                {
                    LogError("Slash operator - Error parsing left expression");
                    return null;
                }

                int rightExpression;
                // Check if right expression is an integer and convert it
                if (Int32.TryParse(expression[1], out rightExpression) == false)
                {
                    LogError("Slash operator - Error parsing right expression");
                    return null;
                }

                // Calculate and return
                var result = leftExpression.Where(v => (v - leftExpression[0]) % rightExpression == 0);
                return result.ToList();
            }
            else
            {
                LogError("Slash operator - Wrong params supplied");
                return null;
            }

        }

        private void LogError(string error)
        {
            Console.WriteLine(error + " - " + _timeUnit.cronValue);
        }
    }
}
