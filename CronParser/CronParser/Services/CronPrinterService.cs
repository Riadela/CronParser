using System;
using System.Collections.Generic;
using CronParser.Pocos;
using CronParser.Services.Interfaces;

namespace CronParser.Services
{
    public class CronPrinterService : ICronPrinterService
    {
        public void PrintList(List<CronOutput> listUnitTime)
        {
            foreach (var timeUnite in listUnitTime)
            {
                Print(timeUnite);
            }
        }

        public void Print(CronOutput unitTime)
        {
            Console.WriteLine("{0,-15} {1,-10}", unitTime.timeField, unitTime.timeValue);
        }
    }
}
