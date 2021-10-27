using System;
using System.Collections.Generic;
using CronParser.Pocos;

namespace CronParser.Services.Interfaces
{
    public interface ICronPrinterService
    {
        void PrintList(List<CronOutput> listUnitTime);
        void Print(CronOutput unitTime);
    }
}
