using System;
using Starcounter;

namespace KitchenSink {
    partial class DatepickerPage : Page {
        protected override void OnData() {
            base.OnData();
            this.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
