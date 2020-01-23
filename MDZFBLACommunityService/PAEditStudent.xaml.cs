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
    /// Interaction logic for PAEditStudent.xaml
    /// </summary>
    public partial class PAEditStudent : Page
    {
        public PAEditStudent()
        {
            InitializeComponent();
            selectedStudentComboBox.ItemsSource = Database.Names();



        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string[] a = selectedStudentComboBox.Text.Split(1," ");

        }
    }
}
