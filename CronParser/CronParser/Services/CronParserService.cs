using System;
using CronParser.Operators.Interfaces;
using CronParser.Pocos;
using CronParser.Services.Interfaces;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.Services
{
    public class CronParserService : ICronParserService
    {
        private readonly IOperatorDelegator _operatorDelegator;

        public CronParserService(IOperatorDelegator operatorDelegator)
        {
            _operatorDelegator = operatorDelegator;
        }

        public CronOutput CronParseUnit(ITimeUnit timeUnit)
        {
            var listValues = _operatorDelegator.OperatorDelegate(timeUnit.unit)?.ApplyOperator();

            if (listValues == null)
                return null;

            return new CronOutput(timeUnit.unitName, string.Join(" ", listValues));
        }

    }
}
