using Starcounter;

namespace KitchenSink {
  partial class DropdownPage : Page {

    public string CalculatedPetReaction {
      get {
        return "You like " + SelectedPet;
      }
    }
  }
}
