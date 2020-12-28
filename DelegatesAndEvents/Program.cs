using System;

namespace DelegatesAndEvents
{
    // 1 Declaration
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    class Program
    {
        static void Main(string[] args)
        {
            // 2 Instantiation
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            del1 += del2 + del3;
            del1(5, WorkType.Golf);
            //DoWork(del2);
            Console.Read();
        }

        private static void DoWork(WorkPerformedHandler del)
        {
            // 3 Invocation
            del(8, WorkType.GenerateReports);
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed1 called: {hours}");
        }

        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed2 called: {hours}");
        }

        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed3 called: {hours}");
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
