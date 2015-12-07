using Starcounter;

namespace KitchenSink {
  partial class DropdownPage : Page {
        protected override void OnData() {
            base.OnData();

            DropdownPage.PetsElementJson pet;
            pet = this.Pets.Add();
            pet.Label = "dogs";

            pet = this.Pets.Add();
            pet.Label = "cats";

            pet = this.Pets.Add();
            pet.Label = "rabbit";

            this.SelectedPet = "dogs";
        }

        public string CalculatedPetReaction {
      get {
        return "You like " + SelectedPet;
      }
    }
  }
}
