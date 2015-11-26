using Starcounter;

namespace KitchenSink {
  partial class TablePage : Page {

    void Handle(Input.AddPet action) {
      var p = Pets.Add();
      p.Name = "Cecil";
      p.Kind = "Hamster";
    }
  }
}
