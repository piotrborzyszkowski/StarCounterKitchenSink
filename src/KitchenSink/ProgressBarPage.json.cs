using Starcounter;

namespace KitchenSink
{
    partial class ProgressBarPage : Json
    {
        public int ProgressValue = 0;
        string seshId;

        protected override void OnData()
        {
            base.OnData();
            seshId = Session.SessionId;
        }

        static ProgressBarPage()
        {
            DefaultTemplate.Progress.Bind = nameof(ProgressValueBind); // Binds ProgressValue to progress in the viewmodel
        }

        public int ProgressValueBind
        {
            get
            {
                return ProgressValue;
            }
        }

        void Handle(Input.StartProgress action) // Button Input
        {
            if (ProgressValue == 0 || ProgressValue == 100)
            {
                ProgressValue = 0;
                StartSimpleProgressBar(30);
            }

            ProgressValue = 0;
        }

        void StartSimpleProgressBar(int timer)
        {
            Scheduling.ScheduleTask(() =>
            {
                while (ProgressValue < 100)
                {
                    System.Threading.Thread.CurrentThread.Join(timer); // sleep function - handles the delay between the incrementation of ProgressValue
                    SimpleProgressUpdate();
                }
            });
        }

        void SimpleProgressUpdate()
        {
            Session.ScheduleTask(seshId, (s, id) =>
            {
                if (ProgressValue < 100)
                {
                    ProgressValue++;
                }
                s.CalculatePatchAndPushOnWebSocket();
            });
        }
    }
}
