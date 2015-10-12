using Starcounter;

namespace KitchenSink {
  partial class TextPage : Page {

    public string CalculatedNameReaction {
      get {
        if (Name == "") {
          return "What's your name?";
        }
        else {
          return "Hi, " + Name + "!";
        }
      }
    }
  }
}
