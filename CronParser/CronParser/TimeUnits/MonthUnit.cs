using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.TimeUnits
{
    public class MonthUnit : ITimeUnit
    {
        public Unit unit { get; }
        public string unitName { get; } = "month";

        public MonthUnit(string cronValue)
        {
            unit = new Unit(1, // minValue
                            12, // maxValue
                            cronValue, // cron expression 
                            new HashSet<char>() { Constants.COMMA_OPERATOR, Constants.RANGE_OPERATOR,
                                                  Constants.ASTERISK_OPERATOR, Constants.SLASH_OPERATOR });  // accepted operators
        }
    }
}
