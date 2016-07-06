using Starcounter;

namespace KitchenSink {
    [Database]
    public class SharedPosition {
        public double Latitude;
        public double Longitude;
    }

    partial class GeoPage : Json {
        //Stockholm coordinates
        public readonly double DefaultLatitude = 59.3319913;
        public readonly double DefaultLongitude = 18.0765409;

        public void Init() {
            Position.Data = Db.SQL<SharedPosition>("SELECT sp FROM SharedPosition sp").First;
            if (Position.Data == null) {
                Position.Data = new SharedPosition() {
                    Latitude = DefaultLatitude,
                    Longitude = DefaultLongitude
                };
                Transaction.Commit();
            }
        }
    }

    [GeoPage_json.Position]
    partial class GeoPagePosition : Json, IBound<SharedPosition> {
        public void Handle(Input.Reset action) {
            Latitude  = ((GeoPage)Parent).DefaultLatitude;
            Longitude = ((GeoPage)Parent).DefaultLongitude;
            PushChanges();
        }

        public void Handle(Input.EventPositionChange action) {
            PushChanges();
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
            Transaction.Commit();
        }
    }
}
