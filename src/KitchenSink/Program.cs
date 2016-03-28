using System.Linq;
using Starcounter;
using KitchenSink.Herlper;
using System;

namespace KitchenSink
{
    class Program
    {
        static void Main()
        {
            var handlerHelper = new HandlerHelper();

            handlerHelper.Register("/KitchenSink/master", (Func<Response>)(() => {
                Session session = Session.Current;

                if (session != null && session.Data != null)
                    return session.Data;

                var master = new MasterPage();

                if (session == null)
                {
                    session = new Session(SessionOptions.PatchVersioning);
                }

                var nav = new NavPage();
                master.CurrentPage = nav;

                master.Session = session;
                return master;
            }));

            handlerHelper.Register("/KitchenSink/json", (Func<Response>)(() => {
                return new Json();
            }));

            handlerHelper.Register("/KitchenSink", () => {
                return Self.GET("/KitchenSink/text");
            });

            handlerHelper.Register<ButtonPage>("/KitchenSink/button");

            handlerHelper.RegisterWithDbScope<BreadcrumbPage>("/KitchenSink/breadcrumb");

            handlerHelper.Register<ChartPage>("/KitchenSink/chart");

            handlerHelper.Register<CheckboxPage>("/KitchenSink/checkbox");

            handlerHelper.Register<DatagridPage>("/KitchenSink/datagrid");

            handlerHelper.Register<DecimalPage>("/KitchenSink/decimal");

            handlerHelper.Register<DropdownPage>("/KitchenSink/dropdown");

            handlerHelper.Register<HtmlPage>("/KitchenSink/html");

            handlerHelper.Register<IntegerPage>("/KitchenSink/integer");

            handlerHelper.Register<MapPage>("/KitchenSink/Map");

            handlerHelper.Register<MarkdownPage>("/KitchenSink/markdown");

            handlerHelper.Register<NestedPartial>("/KitchenSink/nested");

            handlerHelper.Register<RadiolistPage>("/KitchenSink/radiolist");

            handlerHelper.Register<MultiselectPage>("/KitchenSink/multiselect");

            handlerHelper.Register<PasswordPage>("/KitchenSink/password");

            handlerHelper.Register<TablePage>("/KitchenSink/table");

            handlerHelper.Register<TextPage>("/KitchenSink/text");

            handlerHelper.Register<TextareaPage>("/KitchenSink/textarea");

            handlerHelper.Register<RadioPage>("/KitchenSink/radio");

            handlerHelper.Register<RedirectPage>("/KitchenSink/redirect");

            handlerHelper.RegisterWithParam<RedirectPage>("/KitchenSink/Redirect/{?}",
                (MasterPage master, string param) =>
                {
                    var nav = master.CurrentPage as NavPage;
                    var page = nav.CurrentPage as RedirectPage;
                    page.YourFavoriteFood = "You've got some tasty " + param;
                }
            );

            handlerHelper.Register<UrlPage>("/KitchenSink/url");

            handlerHelper.Register<DatepickerPage>("/KitchenSink/datepicker");

            handlerHelper.Register<FileUploadPage>("/KitchenSink/fileupload");

            handlerHelper.Register("/KitchenSink/fileupload/upload", task => {
                Session.ScheduleTask(task.SessionId, (s, id) => {
                    MasterPage master = s.Data as MasterPage;

                    if (master == null)
                    {
                        return;
                    }

                    NavPage nav = master.CurrentPage as NavPage;

                    if (nav == null)
                    {
                        return;
                    }

                    FileUploadPage page = nav.CurrentPage as FileUploadPage;

                    if (page == null)
                    {
                        return;
                    }

                    var item = page.Tasks.FirstOrDefault(x => x.FileName == task.FileName);

                    if (task.State == HandleFile.UploadTaskState.Completed)
                    {
                        if (item != null)
                        {
                            page.Tasks.Remove(item);
                        }

                        var file = page.Files.FirstOrDefault(x => x.FileName == task.FileName);

                        if (file == null)
                        {
                            file = page.Files.Add();
                        }

                        file.FileName = task.FileName;
                        file.FileSize = task.FileSize;
                        file.FilePath = task.FilePath;
                    }
                    else
                    {
                        if (item == null)
                        {
                            item = page.Tasks.Add();
                        }

                        item.FileName = task.FileName;
                        item.FileSize = task.FileSize;
                        item.Progress = task.Progress;

                        if (task.State == HandleFile.UploadTaskState.Error)
                        {
                            item.Message = "Error uploading file";
                        }
                    }

                    s.CalculatePatchAndPushOnWebSocket();
                });
            });

            //for a launcher
            handlerHelper.Register("/KitchenSink/app-name", (Func<Response>)(() => {
                return new AppName();
            }));

            handlerHelper.Register("/KitchenSink/menu", () => {
                return new Partial() { Html = "/KitchenSink/AppMenu(Page.html" };
            });

            UriMapping.Map("/KitchenSink/menu", UriMapping.MappingUriPrefix + "/menu");
            UriMapping.Map("/KitchenSink/app-name", UriMapping.MappingUriPrefix + "/app-name");
        }
    }
}