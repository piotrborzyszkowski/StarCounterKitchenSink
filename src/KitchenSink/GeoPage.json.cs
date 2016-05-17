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
            Session.ForAll((s, sessionId) => {
                var master = s.Data as MasterPage;
                var navpage = master?.CurrentPage as NavPage;
                if (!(navpage?.CurrentPage is GeoPage)) return;
                if ((GeoPage)navpage.CurrentPage != null) {
                    s.CalculatePatchAndPushOnWebSocket();
                }
            });
        }
    }
}
