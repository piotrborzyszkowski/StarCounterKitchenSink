using System;
using System.Timers;
using Starcounter;

namespace KitchenSink
{
    partial class ProgressBarPage : Json
    {
        public int NumberOutput = 0;
        public string StringOutput = "Testers";
        string seshId;

        void Handle(Input.StartSlowProgress action)
        {
            StartProgressBar(80);
        }

        void Handle(Input.StartMediumProgress action)
        {
            StartProgressBar(40);
        }

        void Handle(Input.StartFastProgress action)
        {
            StartProgressBar(20);
        }

        void Handle(Input.StopTimer action)
        {
            this.StartFastProgress = this.StartMediumProgress = this.StartFastProgress = NumberOutput = 0;
            timer.Stop();
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
            timer.Start(); // Update the Starcounter io
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
                this.NumberOutput++;
                s.CalculatePatchAndPushOnWebSocket();
            });
        }

        static ProgressBarPage()
        {
            DefaultTemplate.Name.Bind = nameof(nameBind);
            DefaultTemplate.Number.Bind = nameof(numberBind);
        }

        public string nameBind
        {
            get {
                return StringOutput;
            }
        }

        public int numberBind
        {
            get
            {
                return NumberOutput;
            }
        }
    }
}
