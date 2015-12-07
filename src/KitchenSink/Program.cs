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
                else {
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

            Handle.GET("/KitchenSink/button", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is ButtonPage)) {
                    var page = new ButtonPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/chart", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is ChartPage)) {
                    var page = new ChartPage();

                    page.AddChartData("January", 4);
                    page.AddChartData("February", 7);
                    page.AddChartData("March", 9);
                    page.AddChartData("April", 12);
                    page.AddChartData("May", 15);
                    page.AddChartData("June", 19);

                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/checkbox", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is CheckboxPage)) {
                    var page = new CheckboxPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/datagrid", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is DatagridPage)) {
                    var page = new DatagridPage();

                    DatagridPagePetsElementJson pet;
                    pet = page.Pets.Add();
                    pet.Name = "Rocky";
                    pet.Kind = "Dog";

                    pet = page.Pets.Add();
                    pet.Name = "Tigger";
                    pet.Kind = "Cat";

                    pet = page.Pets.Add();
                    pet.Name = "Bella";
                    pet.Kind = "Rabbit";

                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/decimal", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is DecimalPage)) {
                    var page = new DecimalPage();
                    page.Price = 10;
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/dropdown", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is DropdownPage)) {
                    var page = new DropdownPage();

                    DropdownPage.PetsElementJson pet;
                    pet = page.Pets.Add();
                    pet.Label = "dogs";

                    pet = page.Pets.Add();
                    pet.Label = "cats";

                    pet = page.Pets.Add();
                    pet.Label = "rabbit";

                    page.SelectedPet = "dogs";

                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/html", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is HtmlPage)) {
                    var page = new HtmlPage();
                    page.Bio = @"<h1>This is a markup text</h1>

You can put <strong>any</strong> <a href=""https://en.wikipedia.org/wiki/HTML"">HTML</a> in it.";
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/integer", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is IntegerPage)) {
                    var page = new IntegerPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/Geo", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is MapPage)) {
                    var page = new MapPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/markdown", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is MarkdownPage)) {
                    var page = new MarkdownPage();
                    page.Bio = @"# This is a strucured text

It supports **markdown** *syntax*.";
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/radiolist", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is RadiolistPage)) {
                    var page = new RadiolistPage();
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

            Handle.GET("/KitchenSink/multiselect", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is MultiselectPage)) {
                    var page = new MultiselectPage() {
                        Data = null
                    };
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/password", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is PasswordPage)) {
                    var page = new PasswordPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/table", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is TablePage)) {
                    var page = new TablePage();

                    TablePage.PetsElementJson pet;
                    pet = page.Pets.Add();
                    pet.Name = "Rocky";
                    pet.Kind = "Dog";

                    pet = page.Pets.Add();
                    pet.Name = "Tigger";
                    pet.Kind = "Cat";

                    pet = page.Pets.Add();
                    pet.Name = "Bella";
                    pet.Kind = "Rabbit";

                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/text", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is TextPage)) {
                    var page = new TextPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/textarea", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is TextareaPage)) {
                    var page = new TextareaPage();
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/radio", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is RadioPage)) {
                    var page = new RadioPage();

                    RadioPage.PetsElementJson pet;
                    pet = page.Pets.Add();
                    pet.Label = "dogs";

                    pet = page.Pets.Add();
                    pet.Label = "cats";

                    pet = page.Pets.Add();
                    pet.Label = "rabbit";

                    page.SelectedPet = "dogs";

                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/url", () => {
                var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
                if (!((master.CurrentPage as NavPage).CurrentPage is UrlPage)) {
                    var page = new UrlPage();
                    page.Url = "/KitchenSink";
                    page.Label = "Go to home page";
                    (master.CurrentPage as NavPage).CurrentPage = page;
                }
                return master;
            });

            Handle.GET("/KitchenSink/datepicker", () => {
                return WrapPage(() => new DatepickerPage() { Data = null });
            });

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

        private static Page WrapPage(Func<Page> Page) {
            var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
            var nav = master.CurrentPage as NavPage;

            if (nav.CurrentPage != null && nav.CurrentPage.GetType().Equals(Page.GetType())) {
                return master;
            }

            nav.CurrentPage = Page();

            return master;
        }
    }
}