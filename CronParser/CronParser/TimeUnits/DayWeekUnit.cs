using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.TimeUnits.Interfaces;

namespace CronParser.TimeUnits
{
    public class DayWeekUnit : ITimeUnit
    {
        public Unit unit { get; }
        public string unitName { get; } = "day of week";

        public DayWeekUnit(string cronValue)
        {
            unit = new Unit(1, // minValue
                            7, // maxValue
                            cronValue, // cron expression 
                            new HashSet<char>() { Constants.COMMA_OPERATOR, Constants.RANGE_OPERATOR,
                                                  Constants.ASTERISK_OPERATOR, Constants.SLASH_OPERATOR });  // accepted operators
        }
    }
}
