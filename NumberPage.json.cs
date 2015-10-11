using Starcounter;
using System;

namespace KitchenSink {
  partial class NumberPage : Page {

    void Handle(Input.EditMe action) {
      if (action.Value == 0) {
        this.Reaction = this.Template.Reaction.DefaultValue;
      }
      else {
        this.Reaction = "You were born in " + (DateTime.Now.Year - action.Value);
      }
    }
  }
}
