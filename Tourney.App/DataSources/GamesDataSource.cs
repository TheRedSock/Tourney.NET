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
    class GamesDataSource
    {
        public GamesDataSource()
        {
            // Hacky solution to make the data load in correct order.
            Task.Run(() => this.LoadGames()).Wait();
        }

        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();

        private async Task LoadGames()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync("http://localhost:56041/api/games");
                    var content = responseMessage.Content.ReadAsStringAsync();
                    Games = JsonConvert.DeserializeObject<ObservableCollection<Game>>(content.Result);
                    Debug.WriteLine(Games[0].Name);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
