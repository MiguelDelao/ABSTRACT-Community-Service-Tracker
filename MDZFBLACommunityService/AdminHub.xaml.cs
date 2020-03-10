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
using LiteDB;

namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for AdminHub.xaml
    /// </summary>
    public partial class AdminHub : Window
    {


       
        public AdminHub()
        {
            InitializeComponent();
            Database db = new Database();
            MainFrame.Navigate(new PASelectStudent());

       
        }
        
        


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
           
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AllPeople_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PAAllStudents());

        }


        private void CreateNewStudent_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PACreateStudent());
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            var help = new HelpWindow();
            help.Show();
            

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


        private void StudentView_Click(object sender, RoutedEventArgs e)
        {
            
            Person p = Database.FindByID(int.Parse(IDTextBox.Text));
            if (IDTextBox.Text == "0000") MessageBox.Show("Make sure to select someone first");
            else MainFrame.Navigate(new StudentViewPage(p));
        }

        private void SelectPerson_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PASelectStudent());

            
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var p = Database.FindByID(int.Parse(IDTextBox.Text));

            MainFrame.Navigate(new PAEditStudent());

            
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PAStatistics());
        }



        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Title = "Help Window";
            help.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new StudentView(Database.FindByID(9430));
            x.Show();
        }
    }

}
