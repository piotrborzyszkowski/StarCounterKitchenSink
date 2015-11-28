using Starcounter;

namespace KitchenSink {
  partial class RadiolistPage : Page {

    public void SelectOption(int index) {
      SelectedItemLabel = MenuOptions[index].Label;
    }

    void Handle(Input.SelectedItemIndex action) {
      SelectOption((int)action.Value);
    }
  }

  [RadiolistPage_json.MenuOptions]
  partial class MenuOptionsElement : Json {

    void Handle(Input.Choose action) {
      Label = "!";
    }
  }
}
