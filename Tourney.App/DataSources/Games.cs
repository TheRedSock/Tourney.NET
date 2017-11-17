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
    class Games
    {
        public static Games Instance { get; } = new Games();

        private const string baseUri = "http://localhost:56041/api/";

        HttpClient _client;

        private Games()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<Game[]> GetGames()
        {
            var json = await _client.GetStringAsync("games").ConfigureAwait(false);
            Game[] games = JsonConvert.DeserializeObject<Game[]>(json);
            return games;
        }

        public async Task<bool> DeleteGame(Game game)
        {
            var response = await _client.DeleteAsync($"games\\{game.GameId}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound;
        }

        public async Task<bool> AddGame(Game game)
        {
            string postBody = JsonConvert.SerializeObject(game);
            var response = await _client.PostAsync("games", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
