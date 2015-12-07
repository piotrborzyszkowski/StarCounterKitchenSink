using Starcounter;

namespace KitchenSink {
  partial class UrlPage : Partial {
        protected override void OnData() {
            base.OnData();

            this.Url = "/KitchenSink";
            this.Label = "This a sample link";
        }
    }
}
