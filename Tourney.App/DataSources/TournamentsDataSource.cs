using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tourney.Model;

namespace Tourney.App.DataSources
{
    class TournamentsDataSource
    {
        public TournamentsDataSource()
        {
            Task.Run(() => this.LoadTournaments()).Wait();
        }

        public ObservableCollection<Tournament> Tournaments { get; set; } = new ObservableCollection<Tournament>();

        private async Task LoadTournaments()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync("http://localhost:56041/api/tournaments");
                    var content = responseMessage.Content.ReadAsStringAsync();
                    Tournaments = JsonConvert.DeserializeObject<ObservableCollection<Tournament>>(content.Result);

                    foreach (Tournament t in Tournaments)
                    {
                        var games = new GamesDataSource().Games;
                        t.Game = games.Single(x => x.GameId == t.GameId);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
