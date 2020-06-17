using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tournament.Exceptions;
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Players;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for RemovePlayerWindow.xaml
    /// </summary>
    public partial class RemovePlayer : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public ViewPlayers ViewPlayers { get; set; }
        public RemovePlayer(ViewPlayers viewPlayers, PlayersViewModel playersViewModel)
        {
            ViewPlayers = viewPlayers;
            PlayersViewModel = playersViewModel;
            InitializeComponent();
        }
        private void Error(string text)
        {
            ErrorWindow errorNameWindow = new ErrorWindow();
            errorNameWindow.ErrorContent.Text = text;
            errorNameWindow.Show();
        }
        private Player Read(string name, string surname ,string id)
        {
            int ID;
            Player player;
            try
            {
                ID = int.Parse(IDTextBox.Text);
                if (ID < 0)
                    throw new IDException("Negative ID ",id);
                else
                    player = PlayersViewModel.Players.FindByID(ID);

                if (player == null)
                {
                    throw new IDException("No player with following ID",id);
                }
                if (name != player.Name)
                {
                    throw new NameException("Wrong Name",name);
                }
                if (surname != player.Surname)
                {
                    throw new SurnameException("Wrong Surname",surname);
                }
                
            }
            catch(IDException) 
            {
                throw new IDException("Wrong ID", id);
            }

            return player;
        }
        private void Button_Click_RemovePlayer(object sender, RoutedEventArgs e)
        {
            try
            {
                Player player = Read( NameTextBox.Text, SurnameTextBox.Text, IDTextBox.Text);
                
                PlayersViewModel.Players.Remove(player);
                ViewPlayers.Refresh();
                NavigationService.Navigate(ViewPlayers);
                Error("Succesfully removed Player");

            }
            catch (NameException ex)
            {
                Error(ex.Message);
            }
            catch (SurnameException ex)
            {
                Error(ex.Message);
            }
            catch (IDException ex)
            {
                Error(ex.Message);
            }


           
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewPlayers.Refresh();
            NavigationService.Navigate(ViewPlayers);
        }
    }
}
