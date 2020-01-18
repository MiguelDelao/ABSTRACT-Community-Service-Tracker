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
using LiteDB;

namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for AdminAllPeople.xaml
    /// </summary>
    public partial class AdminAllPeople : Page
    {
        
        public AdminAllPeople()
        {
            InitializeComponent();
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase("//mydata.db"))
                AllStudentsDataGrid.ItemsSource = Database.People();
           
        }

        private void AllStudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Person)AllStudentsDataGrid.SelectedItem;
            firstNameTextBox.Text = selected.FirstName;
            lastNameTextBox.Text = selected.LastName;
            GradeComboBox.Text = string.Concat(selected.Grade);
            hoursTextBox.Text = string.Concat(selected.Hours);
            IDTextbox.Text = string.Concat(selected.ID);
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            

            var selected = (Person)AllStudentsDataGrid.SelectedItem;
            try
            {
                selected.FirstName = firstNameTextBox.Text;
                selected.LastName = lastNameTextBox.Text;
                selected.Grade = int.Parse(GradeComboBox.Text);
                selected.Hours = int.Parse(hoursTextBox.Text);
                Database.Update(selected);
                AllStudentsDataGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("make sure everything is filled out");
            }
        }
    }
}
