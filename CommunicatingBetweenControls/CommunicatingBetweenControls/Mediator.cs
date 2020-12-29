using CommunicatingBetweenControls.Model;
using System;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        // mediator is a singleton object so all components can access the same instance
        private static readonly Mediator _instance = new Mediator();
        public event EventHandler<JobChangedEventArgs> JobChanged;
        private Mediator()
        {

        }

        public static Mediator GetInstance()
        {
            return _instance;
        }

        public void OnJobChanged(object sender, Job job)
        {
            if (JobChanged != null)
            {
                JobChanged(sender, new JobChangedEventArgs { Job = job });
            }
        }
    }
}
