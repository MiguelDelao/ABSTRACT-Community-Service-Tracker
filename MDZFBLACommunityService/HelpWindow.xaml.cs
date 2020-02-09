using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();

            
            

            blo.ItemsSource = Database.People();



        }


        public void Seat()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var pep = Database.People();
            foreach (Person p in pep)
            {

            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Datgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
