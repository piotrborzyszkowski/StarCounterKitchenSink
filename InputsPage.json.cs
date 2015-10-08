using Starcounter;

namespace KitchenSink {
  partial class InputsPage : Page {
    void Handle(Input.Name action) {
      if (action.Value == "") {
        this.NameReaction = this.Template.NameReaction.DefaultValue;
      }
      else {
        this.NameReaction = "Hi, " + action.Value + "!";
      }
    }
  }
}
