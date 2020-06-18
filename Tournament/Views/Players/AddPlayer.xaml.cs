using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.Exceptions;
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Players;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public ViewPlayers ViewPlayers { get; set; }
        public AddPlayer(ViewPlayers viewPlayers, PlayersViewModel playersViewModel)
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
        private Player Read(string name, string surname)
        {
            try
            {
                if (name == string.Empty)
                    throw new NameException("Name is empty");
                if (surname == string.Empty)
                    throw new SurnameException("Surname is empty");
                return new Player() { Name = name, Surname = surname };
            }
            catch
            {
                throw;
            }
        }
        private void Button_Click_AddReferee(object sender, RoutedEventArgs e)
        {
            Player player;
            try
            {
                player = Read(NameTextBox.Text, SurnameTextBox.Text);
                PlayersViewModel.Players.Add(player);
                ViewPlayers.Refresh();
                NavigationService.Navigate(ViewPlayers);
                Error("Succesfully added Referee");
            }
            catch (NameException ex)
            {
                Error(ex.Message);
            }
            catch (SurnameException ex)
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
