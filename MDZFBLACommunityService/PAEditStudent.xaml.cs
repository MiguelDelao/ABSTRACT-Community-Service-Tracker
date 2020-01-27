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
        private Person pep = new Person();
        public PAEditStudent()
        {
            InitializeComponent();
            selectedStudentComboBox.ItemsSource = Database.Names();
            pep = null;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var h = (Hours)StudentListBox.SelectedItem;
            CalendarBox.SelectedDate = h.Date;
            HoursTextbox.Text = string.Concat(h.Hour);


        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string[] a = selectedStudentComboBox.Text.Split(' ');
            var x = Database.FindByName(a[0], a[1]);
            pep = x;
            StudentListBox.ItemsSource = pep.AllHours;
            FnameLabel.Content = pep.FirstName;
            LNameLabel.Content = pep.LastName;
            IDLabel.Content = pep.ID;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime z = CalendarBox.SelectedDate.Value;
                string y = HoursTextbox.Text;
                string x = EventNameTextBox.Text;
                Hours h = new Hours(double.Parse(y), z, x);
                pep.AddHours(h);
                Database.Update(pep);
                StudentListBox.ItemsSource = pep.AllHours;
                
                
            }
            catch
            {

            }
            
        }

        //private void SelectStudentIDButton_Click(object sender, RoutedEventArgs e)
        //{
        //    pep = Database.FindByID(int.Parse(IDTextBox.Text));
        //    StudentListBox.ItemsSource = pep.HoursToString();
        //    FnameLabel.Content = pep.FirstName;
        //    LNameLabel.Content = pep.LastName;
        //    IDLabel.Content = pep.ID;
        //}
    }
}
