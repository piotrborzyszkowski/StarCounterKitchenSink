using Starcounter;

namespace KitchenSink {
  partial class ChartPage : Page {

    public void AddChartData(string label, int value) {
      Json labelItem = Labels.Add();
      labelItem.StringValue = label;

      Json temperatureItem = Temperatures.Add();
      temperatureItem.IntegerValue = value;
    }
  }
}
