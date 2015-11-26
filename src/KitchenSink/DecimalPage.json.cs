using Starcounter;

namespace KitchenSink {
  partial class DecimalPage : Page {

    public string CalculatedPriceReaction {
      get {
        return "5% of tax is " + (Price / 20);
      }
    }
  }
}
