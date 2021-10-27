using System;
using CronParser.Pocos;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.Services.Interfaces
{
    public interface ICronParserService
    {
        CronOutput CronParseUnit(ITimeUnit timeUnit);
    }
}
