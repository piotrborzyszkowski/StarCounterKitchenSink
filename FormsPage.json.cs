using Starcounter;
using System;

namespace KitchenSink {
  partial class FormsPage : Page {

    public string CalculatedNameReaction {
      get {
        if (Name == "") {
          return "What's your name?";
        }
        else {
          return "Hi, " + Name + "!";
        }
      }
    }

    public string CalculatedAgeReaction {
      get {
        DateTime today = DateTime.Today;
        long birthYear = today.Year - Age - 1;
        return "You were born in " + birthYear;
      }
    }

    public string CalculatedDrivingLicenseReaction {
      get {
        if (DrivingLicense == true) {
          return "You can drive";
        }
        else {
          return "You can't drive";
        }
      }
    }

  }
}
