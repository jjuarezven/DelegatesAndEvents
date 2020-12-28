using System;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs eventArgs);
    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public Worker()
        {
            WorkPerformed = new WorkPerformedHandler(WorkPerformed1);
            WorkCompleted = new EventHandler(WorkFinished);
        }

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            if (WorkPerformed != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }
        }

        public int WorkPerformed1(object sender, WorkPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"WorkPerformed1 called: {eventArgs.Hours}");
            return eventArgs.Hours + 1;
        }

        public void WorkFinished(object sender, EventArgs e)
        {
            Console.WriteLine("The work has finished");
        }
    }
}
