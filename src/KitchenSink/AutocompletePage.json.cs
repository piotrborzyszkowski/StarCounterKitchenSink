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
            foreach (var breadcrumb in FoundBreadcrumbs) {
                breadcrumb.SelectAction = () => {
                    FoundBreadcrumbs.Clear();
                    BreadcrumbsSearch = breadcrumb.Name;
                };
            }
        }

        public void Handle(Input.ClearBreadcrumbs _) {
            this.FoundBreadcrumbs.Clear();
        }

        [AutocompletePage_json.FoundBreadcrumbs]
        public partial class FoundBreadcrumbsItem {
            public Action SelectAction { get; set; }
            void Handle(Input.Select action) => SelectAction();
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
                json.SelectAction = () => {
                    FoundPlaces.Clear();
                    PlacesSearch = foundPlace;
                };
            }
        }

        public void Handle(Input.ClearPlaces _) {
            this.FoundPlaces.Clear();
        }

        [AutocompletePage_json.FoundPlaces]
        public partial class FoundPlacesItem {
            public Action SelectAction { get; set; }
            void Handle(Input.Select action) => SelectAction();
        }
    }
}