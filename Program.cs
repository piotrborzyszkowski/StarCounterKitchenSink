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

        standalone.Session = session;
        return standalone;
      });

      Handle.GET("/KitchenSink", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!(master.CurrentPage is InputsPage)) {
          master.CurrentPage = new InputsPage();
        }
        return master;
      });
    }
  }
}