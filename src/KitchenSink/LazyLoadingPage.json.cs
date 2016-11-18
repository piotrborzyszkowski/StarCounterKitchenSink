using Starcounter;
using System.Threading;
using System;

namespace KitchenSink
{
    partial class LazyLoadingPage : Json
    {
        protected override void OnData()
        {
            base.OnData();
            FillDummyData();
        }

        private void FillDummyData()
        {
            CreatePerson(1, "Alicia", "Alcott", "");
            CreatePerson(2, "Beatrice", "Black", "");
            CreatePerson(3, "Claire", "Clancy", "");
            CreatePerson(4, "Delilah", "Darcy", "");
            CreatePerson(5, "Ellie", "Earnhart", "");
            CreatePerson(6, "Faith", "Fahrlander", "");
            CreatePerson(7, "Grace", "Gather", "");
        }

        private void CreatePerson(int order, string firstName, string lastName, string favoriteGame)
        {
            LazyLoadingPagePeople person;
            person = People.Add();
            person.Order = order;
            person.FirstName = firstName;
            person.LastName = lastName;
            person.FavoriteGame = favoriteGame;
        }

        [LazyLoadingPage_json.People]
        partial class LazyLoadingPagePeople : Json
        {
            public LazyLoadingPage ParentPage
            {
                get
                {
                    return this.Parent.Parent as LazyLoadingPage;
                }
            }

            public void Handle(Input.IsHovered action)
            {
                if (!this.DataIsLoaded && action.Value != 0)
                {
                    Random rnd = new Random(); // Adding a random load-time, between half a second, and 1 second.
                    StartDataRetrieval(rnd.Next(3, 10), Session.SessionId);
                }
            }

            void StartDataRetrieval(int delay, string sessionId)
            {
                long loadingProgress = 0;

                Scheduling.ScheduleTask(() =>
                {
                    while (loadingProgress < 100)
                    {
                        System.Threading.Thread.CurrentThread.Join(delay); // sleep function - handles the delay between the incrementation of this.Progress
                        loadingProgress++;
                        DataRetrievalUpate(sessionId, loadingProgress);
                    }
                }, false); // Wait for completion - If false: it will continue to run the script even though the scheduled task is running in the background
            }

            void DataRetrievalUpate(string sessionId, long loadingProgress)
            {
                Session.ScheduleTask(sessionId, (session, id) =>
                {
                    if (session == null)
                    {
                        return;
                    }

                    if (loadingProgress >= 100)
                    {
                        if (this.ParentPage.SelectedPersonsName == this.FirstName) 
                        // Can still be bugged, if the person spam hovers 2 targets for example, there is a change that this person is hovered again*, which will cause the data to load instantly
                        {
                            RetrieveDataFromFakeDataBase(this.FirstName);
                            this.DataIsLoaded = true;
                            this.ParentPage.DisplayedData.DataContent = this.FavoriteGame = this.DataToShow;
                        }
                    }

                    session.CalculatePatchAndPushOnWebSocket();
                });
            }

            public void RetrieveDataFromFakeDataBase(string firstName) // Retrieves different "data" depending on who's calling this function
            {
                switch (firstName)
                {
                    case "Alicia":
                        this.DataToShow = this.FavoriteGame = "The Last of Us";
                        break;

                    case "Beatrice":
                        this.DataToShow = this.FavoriteGame = "Dragon Age: Inquisition";
                        break;

                    case "Claire":
                        this.DataToShow = this.FavoriteGame = "Final Fantasy XIII";
                        break;

                    case "Delilah":
                        this.DataToShow = this.FavoriteGame = "World of Warcraft";
                        break;

                    case "Ellie":
                        this.DataToShow = this.FavoriteGame = "Overwatch";
                        break;

                    case "Faith":
                        this.DataToShow = this.FavoriteGame = "Pokemon X";
                        break;

                    case "Grace":
                        this.DataToShow = this.FavoriteGame = "Counter Strike";
                        break;
                }
            }
        }
    }
}
