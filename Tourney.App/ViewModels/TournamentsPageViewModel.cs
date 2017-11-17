using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Tourney.App.DataSources;
using Tourney.Model;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http.Headers;

namespace Tourney.App.ViewModels
{
    public class DeleteTournamentCommand : ICommand
    {
        private TournamentsPageViewModel _viewModel;

        public DeleteTournamentCommand(TournamentsPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => parameter != null;

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                if (await DataSources.Tournaments.Instance.DeleteTournament((Tournament)parameter))
                {
                    _viewModel.Tournaments.Remove(((Tournament)parameter));
                }
            }
        }
    }

    public class TournamentsPageViewModel : ViewModelBase
    {
        public TournamentsPageViewModel()
        {
            DeleteTournamentCommand = new DeleteTournamentCommand(this);
        }

        ObservableCollection<Tournament> tournaments;
        public ObservableCollection<Tournament> Tournaments { get { return tournaments; } set { Set(ref tournaments, value); } }

        ObservableCollection<Game> games;
        public ObservableCollection<Game> Games { get { return games; } set { Set(ref games, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (Tournaments == null)
            {
                Tournaments = new ObservableCollection<Tournament>(await DataSources.Tournaments.Instance.GetTournaments());
                Games = new ObservableCollection<Game>(await DataSources.Games.Instance.GetGames());
            }

            if (suspensionState.Any())
            {
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public ICommand DeleteTournamentCommand { get; set; }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
