using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for StudentHub.xaml
    /// </summary>
    public partial class StudentHub : Window
    {
        private Person per;

        public StudentHub()
        {
            InitializeComponent();
        }

        public StudentHub(object p)
        {
            InitializeComponent();
            per = (Person)p;

            FirstNameLabel.Content = per.FirstName + " " + per.LastName;
            


        }


        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Prefrences_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PSAddHours pSAdd = new PSAddHours(per);
            MainFrame.Navigate(pSAdd);

        }

        private void RankingButton_Click(object sender, RoutedEventArgs e)
        {
            PSStudentRanking ranking = new PSStudentRanking(per);
            MainFrame.Navigate(ranking);

        }
    }

}
