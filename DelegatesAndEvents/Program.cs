using System;

namespace DelegatesAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);
    // 1 Declaration

    class Program
    {
        static void Main(string[] args)
        {
            // 2 Instantiation
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2 + del3;
            //int totalHours = del1(null, new WorkPerformedEventArgs(5, WorkType.Golf));
            ////int totalHours = del1(5, WorkType.Golf);
            //// totalHours get the value of the last invoked delegate
            //Console.WriteLine(totalHours);
            //DoWork(del2);

            // events demonstration
            var worker = new Worker();
            // using anonymous method
            //worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //                       {
            //                           Console.WriteLine($"Hours worked: {e.Hours} {e.WorkType}");
            //                       };
            // using lambda expressions
            worker.WorkPerformed += (s, e) => Console.WriteLine($"Hours worked: {e.Hours} {e.WorkType}");
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(5, WorkType.GenerateReports);

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            Action<int, int> myActionSum = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myActionMultiply = (x, y) => Console.WriteLine(x * y);

            var data = new ProcessData();
            data.Process(3, 2, multiplyDel);
            data.ProcessAction(5, 7, myActionMultiply);

            Console.Read();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Hours worked: {e.Hours} {e.WorkType}");
        }

        //private static void DoWork(WorkPerformedHandler del)
        //{
        //    // 3 Invocation
        //    del(null, new WorkPerformedEventArgs(8, WorkType.GenerateReports));
        //}

        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed1 called: {hours}");
        //    return hours + 1;
        //}
        static int WorkPerformed1(object sender, WorkPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"WorkPerformed1 called: {eventArgs.Hours}");
            return eventArgs.Hours + 1;
        }

        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed2 called: {hours}");
        //    return hours + 2;
        //}
        static int WorkPerformed2(object sender, WorkPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"WorkPerformed2 called: {eventArgs.Hours}");
            return eventArgs.Hours + 2;
        }

        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed3 called: {hours}");
        //    return hours + 3;
        //}
        static int WorkPerformed3(object sender, WorkPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"WorkPerformed3 called: {eventArgs.Hours}");
            return eventArgs.Hours + 3;
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
