using System;
using Starcounter;

namespace KitchenSink {
  class Program {
    static void Main() {
      Handle.GET("/KitchenSink/standalone", () => {
        Session session = Session.Current;

        if (session != null && session.Data != null)
          return session.Data;

        var standalone = new StandalonePage();

        if (session == null) {
          session = new Session(SessionOptions.PatchVersioning);
          standalone.Html = "/KitchenSink/StandalonePage.html";
        }

        var nav = new NavPage();
        NavPage.NavLinksElementJson a;

        a = nav.NavLinks.Add();
        a.Label = "Forms";
        a.Url = "/KitchenSink/forms";

        a = nav.NavLinks.Add();
        a.Label = "Email";
        a.Url = "/KitchenSink/email";

        a = nav.NavLinks.Add();
        a.Label = "Input";
        a.Url = "/KitchenSink/input";

        a = nav.NavLinks.Add();
        a.Label = "Menu";
        a.Url = "/KitchenSink/menu";

        a = nav.NavLinks.Add();
        a.Label = "Number";
        a.Url = "/KitchenSink/number";

        standalone.CurrentPage = nav;

        standalone.Session = session;
        return standalone;
      });

      Handle.GET("/KitchenSink", () => {
        return Self.GET("/KitchenSink/input");
      });

      Handle.GET("/KitchenSink/forms", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is FormsPage)) {
          var page = new FormsPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/email", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is EmailPage)) {
          var page = new EmailPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/input", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is InputPage)) {
          var page = new InputPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/menu", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is MenuPage)) {
          var page = new MenuPage();
          MenuOptionsElement a;
          a = page.MenuOptions.Add();
          a.Label = "Dogs";
          a = page.MenuOptions.Add();
          a.Label = "Cats";
          page.SelectOption(0);
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/number", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is NumberPage)) {
          var page = new NumberPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });
    }
  }
}