using System;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;
using System.Linq;

namespace CronParser.Operators
{
    public class OperatorDelegator : IOperatorDelegator
    {
        public IOperator OperatorDelegate(Unit timeUnit)
        {
            if (timeUnit.cronValue.Contains(Constants.SLASH_OPERATOR))
                return new SlashOperator(timeUnit, this);

            if (timeUnit.cronValue == Constants.ASTERISK_OPERATOR.ToString())
                return new AsteriskOperator(timeUnit);

            if (timeUnit.cronValue.Contains(Constants.RANGE_OPERATOR))
                return new RangeOperator(timeUnit);

            if (timeUnit.cronValue.Contains(Constants.COMMA_OPERATOR))
                return new CommaOperator(timeUnit);

            return new ValueOperator(timeUnit);
        }

    }
}
