using Starcounter;

namespace KitchenSink {
  partial class TextareaPage : Partial {

    public string CalculatedBioReaction {
      get {
        return "Length of your bio: " + Bio.Length + " chars";
      }
    }
  }
}
