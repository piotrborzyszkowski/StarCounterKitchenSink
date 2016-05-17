using Starcounter;

namespace KitchenSink {
    partial class GeoPage : Json {

    }

    //TODO change me to a database class (then the below setters and getters can be removed)
    public static class SharedPosition {
        public static double Latitude = 59.3319913;
        public static double Longitude = 18.0765409;
    }

    [GeoPage_json.Position]
    partial class GeoPagePosition : Json {
        public double Latitude {
            set {
                SharedPosition.Latitude = value;
                PushChanges();
            }
            get {
                return SharedPosition.Latitude;
            }
        }

        public double Longitude {
            set {
                SharedPosition.Longitude = value;
                PushChanges();
            }
            get {
                return SharedPosition.Longitude;
            }
        }

        protected void PushChanges() {
            Session.ForAll((Session s, string sessionId) => {
                MasterPage master = s.Data as MasterPage;
                if (master != null && master.CurrentPage is NavPage) {
                    NavPage navpage = (NavPage)master.CurrentPage;
                    if (navpage.CurrentPage is GeoPage) {
                        GeoPage page = (GeoPage)navpage.CurrentPage;
                        if (page != null) {
                            s.CalculatePatchAndPushOnWebSocket();
                        }
                    }
                }
            });
        }
    }
}
