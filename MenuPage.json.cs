using Starcounter;
using System;

namespace KitchenSink {
  partial class MenuPage : Page {

    public void SelectOption(int index) {
      this.SelectedItemLabel = this.MenuOptions[index].Label;
    }

    void Handle(Input.SelectedItemIndex action) {
      SelectOption((int)action.Value);
    }
  }

  [MenuPage_json.MenuOptions]
  partial class MenuOptionsElement : Json {

    void Handle(Input.Choose action) {
      this.Label = "!";
    }
  }
}
