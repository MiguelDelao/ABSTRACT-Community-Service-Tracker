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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for PASelectStudent.xaml
    /// </summary>
    public partial class PASelectStudent : Page
    {

        public PASelectStudent()
        {
            InitializeComponent();
            selectedStudentComboBox.ItemsSource = Database.Names();
        }

        private void SelectedStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AdminHub) as AdminHub;
            Person pp = Database.FindByID(int.Parse(selectedStudentID.Text));

            mw.SelectedStudentLabel.Content = (pp.FirstName + " " + pp.LastName);
            mw.IDTextBox.Text = string.Concat(pp.ID);

        }

        private void Testbutt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectStudentButtonByName_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AdminHub) as AdminHub;
            string[] a = selectedStudentComboBox.Text.Split(' ');
            var pep = Database.FindByName(a[0], a[1]);
            mw.SelectedStudentLabel.Content = (pep.FirstName + " " + pep.LastName);
            mw.IDTextBox.Text = string.Concat(pep.ID);


        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

