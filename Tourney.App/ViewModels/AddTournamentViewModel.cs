using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Tourney.Model;
using Tourney.App.DataSources;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace Tourney.App.ViewModels
{
    public class AddTournamentViewModel : ViewModelBase
    {
        public AddTournamentViewModel()
        {
        }

        public ObservableCollection<Game> Games = new GamesDataSource().Games;

        public string TournamentName { get; set; }
        public Game TournamentGame { get; set; }
        public DateTime TournamentDate { get; set; }

        public async void AddTournament()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("http://localhost:56041");
                    var contentJson = JsonConvert.SerializeObject(new Tournament()
                    {
                        Name = TournamentName,
                        Game = TournamentGame
                    });

                    var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("/api/tournaments", content);

                    Debug.WriteLine(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            GotoTournaments();
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

        public void GotoTournaments() =>
            NavigationService.Navigate(typeof(Views.TournamentsPage));
    }
}
