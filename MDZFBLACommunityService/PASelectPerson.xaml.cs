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
    /// Interaction logic for PASelectPerson.xaml
    /// </summary>
    public partial class PASelectPerson : Page
    {
        public PASelectPerson()
        {
            InitializeComponent();
        }

        private void SelectedStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AdminHub) as AdminHub;
            Person pp = Database.FindByID(int.Parse(selectedStudentID.Text));
            mw.FirstNameLabel.Content = pp.FirstName;
            mw.LastNameLabel.Content = pp.LastName;
            mw.IDtlabel.Content = pp.ID;
            
        }

        private void Testbutt_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
