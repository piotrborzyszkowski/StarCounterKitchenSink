using System;
using System.Collections.Generic;
using System.Linq;
using Starcounter;

namespace KitchenSink {
    partial class AutocompletePage : Partial {
        private static readonly String[] AvailablePlaces = new[] {
            "Poland",
            "Sweden",
            "Germany",
            "Norway",
            "Geneva",
            "Pakistan",
            "Portugal",
            "Scotland"
        };

        public void Handle(Input.BreadcrumbsSearch action) {
            var searchTerm = action.Value == "*" ? "%" : $"%{action.Value}%";
            this.FoundBreadcrumbs = Db.SQL("SELECT i FROM TreeItem i WHERE Name LIKE ?", searchTerm);
        }

        public void Handle(Input.ClearBreadcrumbs _) {
            this.FoundBreadcrumbs.Clear();
        }

        [AutocompletePage_json.FoundBreadcrumbs]
        public partial class FoundBreadcrumbsItem {
            void Handle(Input.Select _) {
                var mainPage = (AutocompletePage) Parent.Parent;
                mainPage.FoundBreadcrumbs.Clear();
                mainPage.BreadcrumbsSearch = this.Name;
            }
        }

        public void Handle(Input.PlacesSearch action) {
            Func<string, bool> predicate;
            if (action.Value == "*") {
                predicate = s => true;
            } else {
                predicate = p => p.ToLowerInvariant().StartsWith(action.Value.ToLowerInvariant());
            }

            this.FoundPlaces.Clear();
            foreach (var foundPlace in AvailablePlaces.Where(predicate)) {
                var json = FoundPlaces.Add();
                json.Name = foundPlace;
            }
        }

        public void Handle(Input.ClearPlaces _) {
            this.FoundPlaces.Clear();
        }

        [AutocompletePage_json.FoundPlaces]
        public partial class FoundPlacesItem {
            void Handle(Input.Select _) {
                var mainPage = (AutocompletePage) Parent.Parent;
                mainPage.FoundPlaces.Clear();
                mainPage.PlacesSearch = this.Name;
            }
        }
    }
}