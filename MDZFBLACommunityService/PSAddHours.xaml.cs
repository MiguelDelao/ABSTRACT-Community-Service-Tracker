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
    /// Interaction logic for PSAddHours.xaml
    /// </summary>
    public partial class PSAddHours : Page
    {
        private Person pep;
        public PSAddHours(object p)
        {
            InitializeComponent();
            pep = (Person)p;
            HoursListBox.ItemsSource = pep.AllHours;
        }
        
        
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            pep.AddHours(new Hours(double.Parse(HoursTextbox.Text), CalendarBox.SelectedDate.Value, EventNameTextBox.Text));
            Database.Update(pep);
            HoursListBox.ItemsSource = pep.AllHours;
            HoursListBox.Items.Refresh();
            }

            catch (System.FormatException)
            {
                MessageBox.Show("Make sure everything is the right format");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Make sure everything is selected");
            }

        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var h = (Hours)HoursListBox.SelectedItem;
                CalendarBox.SelectedDate = h.Date;
                HoursTextbox.Text = string.Concat(h.Hour);
                EventNameTextBox.Text = string.Concat(h.Event);
            }
            catch
            {

            }
        }

        private void HoursTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Hours h = (Hours)HoursListBox.SelectedItem;
                    pep.RemoveHours(h);
                    Database.Update(pep);
                    HoursListBox.ItemsSource = pep.AllHours;
                    HoursListBox.Items.Refresh();
                    break;
                case MessageBoxResult.No:
                    //MessageBox.Show("ok");
                    break;
            }
            //Hours h = (Hours)HourListBox.SelectedItem;
            //pep.AllHours.Remove(h);
        }
    }
}
