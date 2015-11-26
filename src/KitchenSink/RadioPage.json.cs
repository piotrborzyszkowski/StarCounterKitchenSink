using Starcounter;

namespace KitchenSink {
  partial class RadioPage : Page {

    public string CalculatedPetReaction {
      get {
        return "You like " + SelectedPet;
      }
    }
  }
}
