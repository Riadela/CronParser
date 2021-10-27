using System;
using CronParser.Pocos;

namespace CronParser.TimeUnits.Interfaces
{
    public interface ITimeUnit
    {
        Unit unit { get; }
        string unitName { get; }
    }
}
