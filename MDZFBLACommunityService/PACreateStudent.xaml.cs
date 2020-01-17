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
            Person temporary = new Person(firstNameTextBox.Text, lastNameTextBox.Text,Database.GenerateID(),int.Parse(GradeComboBox.Text),double.Parse(HoursTextBox.Text));
            Database.Insert(temporary);
        }

    }
}
