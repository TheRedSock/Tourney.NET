using Tourney.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Tourney.App.DataSources
{

    public class Tournaments
    {
        public static Tournaments Instance { get; } = new Tournaments();

        private const string baseUri = "http://localhost:56041/api/";

        HttpClient _client;

        private Tournaments()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<Tournament[]> GetTournaments()
        {
            var json = await _client.GetStringAsync("tournaments").ConfigureAwait(false);
            Tournament[] tournaments = JsonConvert.DeserializeObject<Tournament[]>(json);
            return tournaments;
        }

        public async Task<bool> DeleteTournament(Tournament tournament)
        {
            var response = await _client.DeleteAsync($"tournaments\\{tournament.TournamentId}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound;
        }

        public async Task<bool> AddTournament(Tournament tournament)
        {
            string postBody = JsonConvert.SerializeObject(tournament);
            var response = await _client.PostAsync("tournaments", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}