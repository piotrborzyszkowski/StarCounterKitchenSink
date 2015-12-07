using Starcounter;

namespace KitchenSink {
    partial class RedirectPage : Partial {
        void Handle(Input.TriggerRedirection Action) {
            this.RedirectUrl = "/KitchenSink";
        }
    }
}
