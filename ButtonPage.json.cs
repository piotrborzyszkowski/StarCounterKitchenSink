using Starcounter;

namespace KitchenSink {
  partial class ButtonPage : Page {

    void Handle(Input.AddCarrots action) {
      if (action.Value == 0) {
        CarrotsReaction = Template.CarrotsReaction.DefaultValue;
      }
      else {
        CarrotsReaction = "You have " + action.Value + " imaginary carrots";
      }
    }
  }
}
