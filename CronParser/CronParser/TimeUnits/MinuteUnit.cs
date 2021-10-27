using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.TimeUnits
{
    public class MinuteUnit : ITimeUnit
    {
        public Unit unit { get; }
        public string unitName { get; } = "minute";

        public MinuteUnit(string cronValue)
        {
            unit = new Unit(0, // minValue
                            59, // maxValue
                            cronValue, // cron expression 
                            new HashSet<char>() { Constants.COMMA_OPERATOR, Constants.RANGE_OPERATOR,
                                                  Constants.ASTERISK_OPERATOR, Constants.SLASH_OPERATOR });  // accepted operators
        }
    }
}
