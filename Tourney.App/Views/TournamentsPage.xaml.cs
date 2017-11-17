using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourney.Model;
using Windows.UI.Xaml.Controls;

namespace Tourney.App.Views
{
    public sealed partial class TournamentsPage : Page
    {
        public TournamentsPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        public async void AddTournament()
        {
            var tournament = new Tournament();
            addTournamentContentDialog.DataContext = tournament;

            var result = await addTournamentContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    tournament.Game = (Game)gamesComboBox.SelectedItem;
                    if (await DataSources.Tournaments.Instance.AddTournament(tournament))
                    {
                        Debug.WriteLine(tournament.Name + ", " + tournament.Game.Name);
                        ViewModel.Tournaments.Add(tournament);
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
