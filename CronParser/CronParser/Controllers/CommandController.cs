using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.Services.Interfaces;
using CronParser.TimeUnits;

namespace CronParser.Controllers
{
    public class CommandController
    {
        private const int ARG_MINUTE = 0;
        private const int ARG_HOUR = 1;
        private const int ARG_DAYMONTH = 2;
        private const int ARG_MONTH = 3;
        private const int ARG_DAYWEEK = 4;
        private const int ARG_COMMAND = 5;

        private readonly ICronPrinterService _cronPrinterService;
        private readonly ICronParserService _cronParserService;

        public CommandController(ICronPrinterService cronPrinterService, ICronParserService cronParserService)
        {
            _cronPrinterService = cronPrinterService;
            _cronParserService = cronParserService;
        }

        public void ExecuteCommands(string cronCommand)
        {
            string[] cronArguments = cronCommand.Split(' ');
            var mok = new MinuteUnit(cronArguments[ARG_MINUTE]);

            if (cronArguments.Length == 6)
            {
                List<CronOutput> listOutput = new List<CronOutput>();

                var minute = _cronParserService.CronParseUnit(new MinuteUnit(cronArguments[ARG_MINUTE]));
                if (minute == null)
                    return;
                listOutput.Add(minute);

                var hour = _cronParserService.CronParseUnit(new HourUnit(cronArguments[ARG_HOUR]));
                if (hour == null)
                    return;
                listOutput.Add(hour);

                var dayMonth = _cronParserService.CronParseUnit(new DayMonthUnit(cronArguments[ARG_DAYMONTH]));
                if (dayMonth == null)
                    return;
                listOutput.Add(dayMonth);

                var month = _cronParserService.CronParseUnit(new MonthUnit(cronArguments[ARG_MONTH]));
                if (month == null)
                    return;
                listOutput.Add(month);

                var dayWeek = _cronParserService.CronParseUnit(new DayWeekUnit(cronArguments[ARG_DAYWEEK]));
                if (dayWeek == null)
                    return;
                listOutput.Add(dayWeek);


                var command = new CronOutput("command", cronArguments[ARG_COMMAND]);
                listOutput.Add(command);

                _cronPrinterService.PrintList(listOutput);
            }
            else if (cronArguments.Length < 6)
            {
                Console.WriteLine("Too few arguments");
            }
            else
            {
                Console.WriteLine("Too many argument");
            }
        }
    }
}
