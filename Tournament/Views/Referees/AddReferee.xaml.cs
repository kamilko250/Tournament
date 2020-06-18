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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.Exceptions;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for AddReferee.xaml
    /// </summary>
    public partial class AddReferee : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewReferees ViewReferees { get; set; }
        public AddReferee(RefereesViewModel refereesViewModel, ViewReferees viewReferees)
        {
            RefereesViewModel = refereesViewModel;
            ViewReferees = viewReferees;
            InitializeComponent();
        }
        private void Error(string text)
        {
            ErrorWindow errorNameWindow = new ErrorWindow();
            errorNameWindow.ErrorContent.Text = text;
            errorNameWindow.Show();
        }
        private Referee Read(string name,string surname) 
        {
            try 
            {
                if (name == string.Empty)
                    throw new NameException("Name is empty");
                if (surname == string.Empty)
                    throw new SurnameException("Surname is empty");
                return new Referee() { Name = name, Surname = surname};
            }
            catch 
            {
                throw;
            }
        }
        private void Button_Click_AddReferee(object sender, RoutedEventArgs e)
        {
            Referee referee;
            try
            {
                referee = Read(NameTextBox.Text, SurnameTextBox.Text);
                RefereesViewModel.Referees.Add(referee);
                ViewReferees.Refresh();
                NavigationService.Navigate(ViewReferees);
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
            ViewReferees.Refresh();
            NavigationService.Navigate(ViewReferees);
        }
    }
}
