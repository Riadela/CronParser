using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.TimeUnits
{
    public class HourUnit : ITimeUnit
    {
        public Unit unit { get; }
        public string unitName { get; } = "hour";

        public HourUnit(string cronValue)
        {
            unit = new Unit(0, // minValue
                            23, // maxValue
                            cronValue, // cron expression 
                            new HashSet<char>() { Constants.COMMA_OPERATOR, Constants.RANGE_OPERATOR,
                                                  Constants.ASTERISK_OPERATOR, Constants.SLASH_OPERATOR });  // accepted operators
        }
    }
}
