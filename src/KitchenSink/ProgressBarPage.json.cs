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
            if (this.TaskIsRunnning)
            {
                return;
            }
            this.TaskIsRunnning = true;
            string sessionId = Session.SessionId;

            this.Progress = 0;
            StartSimpleProgressBar(30, sessionId);

        }

        void StartSimpleProgressBar(int delay, string sessionId)
        {
            this.FileDownloadText = "Downloading File";
            var tempProgress = this.Progress;
            Scheduling.ScheduleTask(() =>
            {
                while (tempProgress < 100)
                {
                    System.Threading.Thread.CurrentThread.Join(delay); // sleep function - handles the delay between the incrementation of this.Progress
                    tempProgress++;
                    SimpleProgressUpdate(sessionId, tempProgress);
                }
            }, false); // Wait for completion - If false: it will continue to run the script even though the scheduled task is running in the background
        }

        void SimpleProgressUpdate(string sessionId, long tempProgress)
        {
            Session.ScheduleTask(sessionId, (s, id) =>
            {
                this.Progress = tempProgress;
                if (this.Progress >= 100)
                {
                    this.FileDownloadText = "Download Complete";
                    this.DownloadButtonText = "Download another (imaginary) file!";
                    this.TaskIsRunnning = false;
                }
                s.CalculatePatchAndPushOnWebSocket();
            });
        }
    }
}
