using System;
using CronParser.Pocos;

namespace CronParser.Operators.Interfaces
{
    public interface IOperatorDelegator
    {
        IOperator OperatorDelegate(Unit timeUnit);
    }
}
