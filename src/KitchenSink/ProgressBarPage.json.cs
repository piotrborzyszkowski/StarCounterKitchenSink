using System;
using System.Timers;
using Starcounter;

namespace KitchenSink
{
    partial class ProgressBarPage : Json
    {
        public int ProgressValue = 0;
        public string ProgressDisplay = "Testers";
        string seshId;

        void Handle(Input.StartSlowProgress action)
        {
            StartProgressBar(50);
        }

        void Handle(Input.StartMediumProgress action)
        {
            StartProgressBar(30);
        }

        void Handle(Input.StartFastProgress action)
        {
            StartProgressBar(10);
        }

        void Handle(Input.StopProgress action)
        {
            timer.Stop();
            this.StartFastProgress = this.StartMediumProgress = this.StartFastProgress = ProgressValue = 0;
            this.ButtonsDisabled = false;
        }

        void Handle(Input.PauseProgress action)
        {
            timer.Stop();
            if (ProgressValue != 100)
            {
                this.StartFastProgress = this.StartMediumProgress = this.StartFastProgress = ProgressValue;
                this.ButtonsDisabled = false;
            }
        }

        protected override void OnData()
        {
            base.OnData();
            seshId = Session.SessionId;
        }

        private Timer timer;

        void StartProgressBar(int time)
        {
            int timerTime = 1 * time;
            timer = new Timer(timerTime); // 60 * 1000 = 1 minute interval
            timer.AutoReset = true;
            timer.Elapsed += OnTimer;
            timer.Start(); // Update the Starcounter io - Add this to the example http://starcounter.io/guides/transactions/running-background-jobs/
            this.ButtonsDisabled = true; // Disabled the buttons
        }

        void OnTimer(object sender, ElapsedEventArgs e)
        {
            // Schedule a job on scheduler 0 without waiting for its completion.
            Scheduling.ScheduleTask(() =>
            {
                System.Threading.Thread.CurrentThread.Join(0);
                UpdateProgressBar();
            });
        }

        void UpdateProgressBar ()
        {
            Session.ScheduleTask(seshId, (s, id) =>
            {
                this.ProgressValue++;
                if (ProgressValue == 100)
                {
                    timer.Stop();
                }
                s.CalculatePatchAndPushOnWebSocket();
            });
        }

        static ProgressBarPage()
        {
            DefaultTemplate.Display.Bind = nameof(nameBind);
            DefaultTemplate.Progress.Bind = nameof(numberBind);
        }

        public string nameBind
        {
            get {
                return ProgressDisplay;
            }
        }

        public int numberBind
        {
            get
            {
                return ProgressValue;
            }
        }
    }
}
