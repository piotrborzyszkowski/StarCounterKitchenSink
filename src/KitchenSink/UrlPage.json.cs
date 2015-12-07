using Starcounter;

namespace KitchenSink {
  partial class UrlPage : Page {
        protected override void OnData() {
            base.OnData();

            this.Url = "/KitchenSink";
            this.Label = "Go to home page";
        }
    }
}
