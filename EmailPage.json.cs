using Starcounter;

namespace KitchenSink {
  partial class EmailPage : Page {

    void Handle(Input.EditMe action) {
      if (action.Value == "") {
        this.Reaction = this.Template.Reaction.DefaultValue;
      }
      else {
        this.Reaction = "Sending stuff to " + action.Value;
      }
    }
  }
}
