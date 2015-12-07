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
                } else {
                    standalone.Html = "/KitchenSink/LauncherWrapperPage.html";
                }

                var nav = new NavPage();
                standalone.CurrentPage = nav;

                standalone.Session = session;
                return standalone;
            });

            Handle.GET("/KitchenSink", () => {
                return Self.GET("/KitchenSink/text");
            });

            Handle.GET("/KitchenSink/button", () => WrapPage(() => new ButtonPage()));

            Handle.GET("/KitchenSink/chart", () => WrapPage(() => new ChartPage()));

            Handle.GET("/KitchenSink/checkbox", () => WrapPage(() => new CheckboxPage()));

            Handle.GET("/KitchenSink/datagrid", () => WrapPage(() => new DatagridPage()));

            Handle.GET("/KitchenSink/decimal", () => WrapPage(() => new DecimalPage()));

            Handle.GET("/KitchenSink/dropdown", () => WrapPage(() => new DropdownPage()));

            Handle.GET("/KitchenSink/html", () => WrapPage(() => new HtmlPage()));

            Handle.GET("/KitchenSink/integer", () => WrapPage(() => new IntegerPage()));

            Handle.GET("/KitchenSink/Geo", () => WrapPage(() => new MapPage()));

            Handle.GET("/KitchenSink/markdown", () => WrapPage(() => new MarkdownPage()));

            Handle.GET("/KitchenSink/radiolist", () => WrapPage(() => new RadiolistPage()));

            Handle.GET("/KitchenSink/multiselect", () => WrapPage(() => new MultiselectPage()));

            Handle.GET("/KitchenSink/password", () => WrapPage(() => new PasswordPage()));

            Handle.GET("/KitchenSink/table", () => WrapPage(() => new TablePage()));

            Handle.GET("/KitchenSink/text", () => WrapPage(() => new TextPage()));

            Handle.GET("/KitchenSink/textarea", () => WrapPage(() => new TextareaPage()));

            Handle.GET("/KitchenSink/radio", () => WrapPage(() => new RadioPage()));

            Handle.GET("/KitchenSink/url", () => WrapPage(() => new UrlPage()));

            Handle.GET("/KitchenSink/datepicker", () => WrapPage(() => new DatepickerPage()));

            //for a launcher
            Handle.GET("/KitchenSink/app-name", () => {
                return new AppName();
            });

            Handle.GET("/KitchenSink/menu", () => {
                return new Page() { Html = "/KitchenSink/AppMenuPage.html" };
            });

            UriMapping.Map("/KitchenSink/menu", UriMapping.MappingUriPrefix + "/menu");
            UriMapping.Map("/KitchenSink/app-name", UriMapping.MappingUriPrefix + "/app-name");
        }

        private static Page WrapPage<T>(Func<T> Page) where T : Page {
            var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
            var nav = master.CurrentPage as NavPage;

            if (nav.CurrentPage != null && nav.CurrentPage.GetType().Equals(typeof(T))) {
                return master;
            }

            nav.CurrentPage = Page();
            nav.CurrentPage.Data = null;

            return master;
        }
    }
}