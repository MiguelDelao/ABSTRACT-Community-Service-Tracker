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
        
        public static string ppp;
        
        public AdminHub()
        {
            InitializeComponent();
            Database db = new Database();
            testlabel.Content = ppp;
       
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

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            testlabel.Content = ppp;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SelectPerson_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PASelectPerson());
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PAEditStudent());
        }
    }

}
