using System.Windows.Controls;

namespace CommunicatingBetweenControls.UserControls
{
    /// <summary>
    /// Interaction logic for JobDetails.xaml
    /// </summary>
    public partial class JobDetails : UserControl
    {
        public JobDetails()
        {
            InitializeComponent();
            // sets the action that JobChanged has to perform
            Mediator.GetInstance().JobChanged += (s, e) => DataContext = e.Job;
        }
    }
}
