using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BestBall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardView : ContentPage
    {
        public ObservableCollection<PlayerScorecard> Items { get; set; }

        public LeaderboardView()
        {
            InitializeComponent();

            Items = new ObservableCollection<PlayerScorecard>
            {
                new PlayerScorecard("Joe Stella"),
                new PlayerScorecard("Chris Marting"),
                new PlayerScorecard("Steven Fernicola"),
                new PlayerScorecard("Tyler Toohey"),
                new PlayerScorecard("Paul Vizzio")
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }

    public class PlayerScorecard
    {
        public PlayerScorecard(string name)
        {
            PlayerName = name;
            Id = 1;
            ScorecardId = 1;
            RoundScore = -5;
            HoleScores = new int[] { 5, 4, 3, 4, 5, 3, 2, 3, 4, 5, 4, 3, 4, 5, 3, 2, 3, 4 };
        }
        public int Id { get; set; }
        public int ScorecardId { get; set; }
        public string PlayerName { get; set; }
        public int RoundScore { get; set; }
        public int[] HoleScores { get; set; }
    }
}
