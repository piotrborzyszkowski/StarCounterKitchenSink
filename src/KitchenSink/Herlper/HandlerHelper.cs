using System;
using Starcounter;

namespace KitchenSink.Herlper
{
    public class HandlerHelper
    {
        public void Register(string path, Func<Response> action)
        {
            Handle.GET(path, () => action());
        }

        public void Register(string path, Action<HandleFile.UploadTask> action)
        {
            HandleFile.GET(path, action);
        }

        public void Register<T>(string path) where T : Partial
        {
            RegisterHandlers<T>(path, RegisterPartialHandler<T>);
        }

        public void RegisterWithParam<T>(string path, Action<MasterPage, string> action) where T : Partial
        {
            RegisterHandlers<T>(path, RegisterPartialHandler<T>, action);
        }

        public void RegisterWithDbScope<T>(string path) where T : Partial
        {
            RegisterHandlers<T>(path, RegisterPartialHandlerWithDbScope<T>);
        }

        private void RegisterHandlers<T>(string path, Func<Response> partialHandler) where T : Partial
        {
            var typeName = typeof(T).Name;
            var partialName = string.Format("/KitchenSink/partial/{0}", typeName);

            Handle.GET(partialName, partialHandler);
            Handle.GET(path, () => WrapPage<T>(partialName));
        }

        private void RegisterHandlers<T>(string path, Func<Response> partialHandler, Action<MasterPage, string> action) where T : Partial
        {
            var typeName = typeof(T).Name;
            var partialName = string.Format("/KitchenSink/partial/{0}", typeName);

            Handle.GET(path, (string param) => {
                var master = WrapPage<T>(partialName) as MasterPage;
                action(master, param);
                return master;
            });
        }

        private Response RegisterPartialHandler<T>() where T : Partial
        {
            return Activator.CreateInstance<T>();
        }

        private Response RegisterPartialHandlerWithDbScope<T>() where T : Partial
        {
            return Db.Scope(() => RegisterPartialHandler<T>());
        }

        private Partial WrapPage<T>(string partialPath) where T : Partial
        {
            var master = (MasterPage)Self.GET("/KitchenSink/master");
            var nav = master.CurrentPage as NavPage;

            if (nav.CurrentPage != null && nav.CurrentPage.GetType().Equals(typeof(T)))
            {
                return master;
            }

            nav.CurrentPage = Self.GET(partialPath);

            if (nav.CurrentPage.Data == null)
            {
                nav.CurrentPage.Data = null; //trick to invoke OnData in partial
            }

            return master;
        }
    }
}
