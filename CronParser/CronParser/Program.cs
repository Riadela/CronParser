using System;
using CronParser.Controllers;
using CronParser.Operators;
using CronParser.Operators.Interfaces;
using CronParser.Services;
using CronParser.Services.Interfaces;

namespace CronParser
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IOperatorDelegator operatorDelegator = new OperatorDelegator();
            ICronPrinterService cronPrinterService = new CronPrinterService();

            ICronParserService cronParserService = new CronParserService(operatorDelegator);

            CommandController commandController = new CommandController(cronPrinterService, cronParserService);

            string input = Console.ReadLine();
            commandController.ExecuteCommands(input);
        }
    }
}
