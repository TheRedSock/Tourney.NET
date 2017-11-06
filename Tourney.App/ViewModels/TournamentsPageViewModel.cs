using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Tourney.App.DataSources;
using Tourney.Model;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http.Headers;

namespace Tourney.App.ViewModels
{
    class TournamentsPageViewModel : ViewModelBase
    {
        public TournamentsPageViewModel()
        {
        }

        public ObservableCollection<Tournament> Tournaments = new TournamentsDataSource().Tournaments;

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Tournaments = new TournamentsDataSource().Tournaments;
            await Task.CompletedTask;
        }

        public void GotoAddTournament() =>
            NavigationService.Navigate(typeof(Views.AddTournamentPage));

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
