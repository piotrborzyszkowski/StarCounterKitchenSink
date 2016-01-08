using System;
using Starcounter;

namespace KitchenSink {
    class Program {
        static void Main() {
            Handle.GET("/KitchenSink/master", () => {
                Session session = Session.Current;

                if (session != null && session.Data != null)
                    return session.Data;

                var master = new MasterPage();

                if (session == null) {
                    session = new Session(SessionOptions.PatchVersioning);
                }

                var nav = new NavPage();
                master.CurrentPage = nav;

                master.Session = session;
                return master;
            });

            Handle.GET("/KitchenSink/json", () => {
                return new Json();
            });

            Handle.GET("/KitchenSink", () => {
                return Self.GET("/KitchenSink/text");
            });

            Handle.GET("/KitchenSink/button", () => WrapPage(() => new ButtonPage()));

            Handle.GET("/KitchenSink/breadcrumb", () => WrapPage(() => {
                return Db.Scope(() => {
                    return new BreadcrumbPage();
                });
            }));

            Handle.GET("/KitchenSink/chart", () => WrapPage(() => new ChartPage()));

            Handle.GET("/KitchenSink/checkbox", () => WrapPage(() => new CheckboxPage()));

            Handle.GET("/KitchenSink/datagrid", () => WrapPage(() => new DatagridPage()));

            Handle.GET("/KitchenSink/decimal", () => WrapPage(() => new DecimalPage()));

            Handle.GET("/KitchenSink/dropdown", () => WrapPage(() => new DropdownPage()));

            Handle.GET("/KitchenSink/html", () => WrapPage(() => new HtmlPage()));

            Handle.GET("/KitchenSink/integer", () => WrapPage(() => new IntegerPage()));

            //Handle.GET("/KitchenSink/Map", () => WrapPage(() => new MapPage()));

            Handle.GET("/KitchenSink/Map", () => WrapPage(() => new MapPage()));

            Handle.GET("/KitchenSink/markdown", () => WrapPage(() => new MarkdownPage()));

            Handle.GET("/KitchenSink/nested", () => WrapPage(() => new NestedPartial() {
                Data = new AnyData()
            }));

            Handle.GET("/KitchenSink/radiolist", () => WrapPage(() => new RadiolistPage()));

            Handle.GET("/KitchenSink/multiselect", () => WrapPage(() => new MultiselectPage()));

            Handle.GET("/KitchenSink/password", () => WrapPage(() => new PasswordPage()));

            Handle.GET("/KitchenSink/table", () => WrapPage(() => new TablePage()));

            Handle.GET("/KitchenSink/text", () => WrapPage(() => new TextPage()));

            Handle.GET("/KitchenSink/textarea", () => WrapPage(() => new TextareaPage()));

            Handle.GET("/KitchenSink/radio", () => WrapPage(() => new RadioPage()));

            Handle.GET("/KitchenSink/Redirect", () => WrapPage(() => new RedirectPage()));

            Handle.GET("/KitchenSink/Redirect/{?}", (string param) => {
                var master = WrapPage(() => new RedirectPage()) as MasterPage;
                var nav = master.CurrentPage as NavPage;
                var page = nav.CurrentPage as RedirectPage;
                page.YourFavoriteFood = "You've got some tasty " + param;
                return master;
            });

            Handle.GET("/KitchenSink/url", () => WrapPage(() => new UrlPage()));

            Handle.GET("/KitchenSink/datepicker", () => WrapPage(() => new DatepickerPage()));

            //for a launcher
            Handle.GET("/KitchenSink/app-name", () => {
                return new AppName();
            });

            Handle.GET("/KitchenSink/menu", () => {
                return new Partial() { Html = "/KitchenSink/AppMenuPage.html" };
            });

            UriMapping.Map("/KitchenSink/menu", UriMapping.MappingUriPrefix + "/menu");
            UriMapping.Map("/KitchenSink/app-name", UriMapping.MappingUriPrefix + "/app-name");
        }

        private static Partial WrapPage<T>(Func<T> partial) where T : Partial {
            var master = (MasterPage)Self.GET("/KitchenSink/master");
            var nav = master.CurrentPage as NavPage;

            if (nav.CurrentPage != null && nav.CurrentPage.GetType().Equals(typeof(T))) {
                return master;
            }

            nav.CurrentPage = partial();
            if (nav.CurrentPage.Data == null) {
                nav.CurrentPage.Data = null; //trick to invoke OnData in partial
            }

            return master;
        }
    }
}