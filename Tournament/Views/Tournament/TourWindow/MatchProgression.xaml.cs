using System.Windows;
using Tournament.Models;
using Tournament.Models.Enums;
using Match = Tournament.Models.Match;

namespace Tournament.Views.Tournament.TourWindow
{
    /// <summary>
    /// Interaction logic for MatchProgression.xaml
    /// </summary>
    public partial class MatchProgression : Window
    {
        public Match Match { get; set; }
        public MatchList Planned { get; set; }
        public MatchList History { get; set; }
        public MatchProgression(Match match, MatchList planned, MatchList history)
        {
            InitializeComponent();
            Match = match;
            Planned = planned;
            History = history;
            MatchRank.Text = Match.MatchRanks.ToString();
            TeamA.Text = Match.TeamA.Name.ToString();
            TeamB.Text = Match.TeamB.Name.ToString();
            TeamAPlayers.ItemsSource = match.TeamA.PlayersList.List;
            TeamBPlayers.ItemsSource = match.TeamB.PlayersList.List;
        }
        public void Error(string text)
        {
            ErrorWindow errorWindow = new ErrorWindow() { Width = 400 };
            errorWindow.ErrorContent.Text = text;
            errorWindow.Show();
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            PlayerList teamAPlayers = new PlayerList();
            PlayerList teamBPlayers = new PlayerList();
            int TeamAScore = int.Parse(ScoredTeamA.Text);
            int TeamBScore = int.Parse(ScoredTeamB.Text);

            bool IsTeamAScoreValid;
            bool IsTeamBScoreValid;
            bool IsTeamAPlayersValid;
            bool IsTeamBPlayersValid;

            int PlayersNeededToPlay;


            if (Match.GameTypes == GameTypes.Volleyball)
            {
                PlayersNeededToPlay = 6;
            }
            else if (Match.GameTypes == GameTypes.TugOfWar)
            {
                PlayersNeededToPlay = 5;
            }
            else if (Match.GameTypes == GameTypes.DodgeBall)
            {
                PlayersNeededToPlay = 5;
            }
            else
            {
                Error("Match doesn't have Game Type");
                return;
            }

            foreach (var item in TeamAPlayers.SelectedItems)
            {
                if (item is Player player)
                    teamAPlayers.Add(player);
            }

            foreach (var item in TeamBPlayers.SelectedItems)
            {
                if (item is Player player)
                    teamBPlayers.Add(player);
            }

            if (TeamAScore > 0)
            {
                IsTeamAScoreValid = true;
            }
            else
            {
                Error("Please enter left team score");
                return;

            }

            if (TeamBScore > 0)
            {
                IsTeamBScoreValid = true;
            }
            else
            {
                Error("Please enter right team score");
                return;
            }

            if (teamAPlayers.Count >= PlayersNeededToPlay)
            {
                IsTeamAPlayersValid = true;
            }
            else
            {
                Error("Team A have to has at least " + PlayersNeededToPlay.ToString() + " players.");
                return;
            }

            if (teamBPlayers.Count >= PlayersNeededToPlay)
            {
                IsTeamBPlayersValid = true;
            }
            else
            {
                Error("Team A have to has at least " + PlayersNeededToPlay.ToString() + " players.");
                return;
            }


            if (IsTeamBPlayersValid && IsTeamAPlayersValid && IsTeamBScoreValid && IsTeamAScoreValid)
            {

                Planned.Remove(Match.ID);
                Match.Past_Future = Past_Future.Past;
                Match.TeamAScore = TeamAScore;
                Match.TeamBScore = TeamBScore;
                if (TeamAScore == TeamBScore)
                {
                    Match.TeamA.PointEarned += 1;
                    Match.TeamB.PointEarned += 1;
                }
                else if (TeamAScore>TeamBScore)
                {
                    Match.TeamA.PointEarned += 3;
                }
                else
                {
                    Match.TeamB.PointEarned += 3;
                }
                History.Add(Match);
                Error("Succesfully saved match details");
                Close();
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
