using System;

namespace DelegatesAndEvents
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }
    }
}
