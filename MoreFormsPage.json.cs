using Starcounter;

namespace KitchenSink {
  partial class MoreFormsPage : Page {

    public string CalculatedPetReaction {
      get {
        //return Pets[(int)this.SelectedPet].Label;
        return "You like " + this.SelectedPet;
      }
    }

    void Handle(Input.Shuffle action) {
      if (Pets.Count > 5) {
        return;
      }

      var pet = this.Pets.Add();
      switch (Pets.Count) {
        case 4:
          pet.Label = "goldfish";
          break;

        case 5:
          pet.Label = "hamster";
          break;

        case 6:
          pet.Label = "spider";
          break;
      }

      //
      //pet.Label = "Goldfish";
    }
  }
}
