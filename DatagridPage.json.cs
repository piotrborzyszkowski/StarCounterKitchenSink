using Starcounter;

namespace KitchenSink {
  partial class DatagridPage : Page {

    void Handle(Input.AddPet action) {
      var p = Pets.Add();
      p.Name = "Cecil";
      p.Kind = "Hamster";
    }
  }

  [DatagridPage_json.Pets]
  partial class DatagridPagePetsElementJson : Json {

    public string CalculatedSound {
      get {
        switch (Kind) {
          case "Dog":
            return "Woof";

          case "Cat":
            return "Meow";

          case "Rabbit":
            return "Jump";

          case "Hamster":
            return "Squeak";

          default:
            return "";
        }
      }
    }
  }
}
