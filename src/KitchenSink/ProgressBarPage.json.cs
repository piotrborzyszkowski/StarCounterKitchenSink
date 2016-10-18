using Starcounter;

namespace KitchenSink
{
    partial class ProgressBarPage : Json
    {
        protected override void OnData()
        {
            base.OnData();
        }

        void Handle(Input.StartProgress action) // Button Input
        {
            string sessionId = Session.SessionId;

            if (this.Progress == 0 || this.Progress == 100)
            {
                this.Progress = 0;
                StartSimpleProgressBar(30, sessionId);
            }

            this.Progress = 0;
        }

        void StartSimpleProgressBar(int delay, string sessionId)
        {
            this.FileDownloadText = "Downloading File";
            Scheduling.ScheduleTask(() =>
            {
                while (this.Progress < 100)
                {
                    System.Threading.Thread.CurrentThread.Join(delay); // sleep function - handles the delay between the incrementation of this.Progress
                    SimpleProgressUpdate(sessionId);
                }
            }, false); // Wait for completion - If false: it will continue to run the script even though the scheduleTask is running in the background
        }

        void SimpleProgressUpdate(string sessionId)
        {
            Session.ScheduleTask(sessionId, (s, id) =>
            {
                if (this.Progress < 100)
                {
                    this.Progress++;
                }
                else
                {
                    this.FileDownloadText = "Download Complete";
                    this.DownloadButtonText = "Download another (maginary) file!";
                }
                s.CalculatePatchAndPushOnWebSocket();
            });
        }
    }
}
