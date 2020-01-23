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
    /// Interaction logic for PACreateStudent.xaml
    /// </summary>
    public partial class PACreateStudent : Page
    {
        public PACreateStudent()
        {
            InitializeComponent();
        }

        private void Create_Person_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person temporary = new Person(firstNameTextBox.Text, lastNameTextBox.Text, Database.GenerateID(), 
                    int.Parse(GradeComboBox.Text), double.Parse(HoursTextBox.Text),EventTextBox.Text);
                Database.Insert(temporary);
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Please make sure everything is filled out, and make sure its in the right format");
            }
            
            
        }

        private void EventTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HoursTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
