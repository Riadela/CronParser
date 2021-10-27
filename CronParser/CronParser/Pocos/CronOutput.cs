using System;
namespace CronParser.Pocos
{
    public class CronOutput
    {
        public string timeField { get; } = "";
        public string timeValue { get; } = "";

        public CronOutput(string pField, string pValue)
        {
            timeField = pField;
            timeValue = pValue;
        }
    }
}
