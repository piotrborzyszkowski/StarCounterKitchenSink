using Starcounter;

namespace KitchenSink {
  partial class InputPage : Page {

    void Handle(Input.EditMe action) {
      if (action.Value == "") {
        this.Reaction = this.Template.Reaction.DefaultValue;
      }
      else {
        this.Reaction = "Hi, " + action.Value + "!";
      }
    }
  }
}
