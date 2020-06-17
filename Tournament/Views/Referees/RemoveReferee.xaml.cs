using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Tournament.Exceptions;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for RemoveReferee.xaml
    /// </summary>
    public partial class RemoveReferee : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewReferees ViewReferees { get; set; }
        public RemoveReferee(RefereesViewModel refereesViewModel, ViewReferees viewReferees)
        {
            RefereesViewModel = refereesViewModel;
            ViewReferees = viewReferees;
            InitializeComponent();
        }
        private Referee Read(string name, string surname, string id)
        {
            int ID;
            Referee referee;
            try
            {
                ID = int.Parse(IDTextBox.Text);
                if (ID < 0)
                    throw new IDException("Negative ID ", id);
                else
                    referee = RefereesViewModel.Referees.FindByID(ID);

                if (referee == null)
                {
                    throw new IDException("No player with following ID", id);
                }
                if (name != referee.Name)
                {
                    throw new NameException("Wrong Name", name);
                }
                if (surname != referee.Surname)
                {
                    throw new SurnameException("Wrong Surname", surname);
                }

            }
            catch (IDException)
            {
                throw new IDException("Wrong ID", id);
            }

            return referee;
        }
        private void Button_Click_RemoveReferee(object sender, RoutedEventArgs e)
        {
            try
            {
                Referee referee = Read(NameTextBox.Text, SurnameTextBox.Text, IDTextBox.Text);

                RefereesViewModel.Referees.Remove(referee);
                ViewReferees.Refresh();
                NavigationService.Navigate(ViewReferees);
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
            ViewReferees.Refresh();
            NavigationService.Navigate(ViewReferees);
        }
        private void Error(string text)
        {
            ErrorWindow errorSurnameWindow = new ErrorWindow() { Width = 400 };
            errorSurnameWindow.ErrorContent.Text = text;
            errorSurnameWindow.Show();
        }
    }
}
