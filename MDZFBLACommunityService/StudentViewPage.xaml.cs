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
    /// Interaction logic for StudentViewPage.xaml
    /// </summary>
    public partial class StudentViewPage : Page
    {
        private Person pep;
        public StudentViewPage(object p)
        {
            InitializeComponent();
            pep = (Person)p;

            HoursListView.ItemsSource = pep.AllHours;

            NameLabel.Content = pep.FirstName + " " + pep.LastName;

            ImageRank();
        }

        private void Listviewtest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            pep.AddHours(new Hours(double.Parse(HoursTextbox.Text), CalendarSelecter.SelectedDate.Value, EventNameTextBox.Text));
            Database.Update(pep);
            HoursListView.ItemsSource = pep.AllHours;
            HoursListView.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Make sure everything is filled out");
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Hours h = (Hours)HoursListView.SelectedItem;
                    pep.RemoveHours(h);
                    Database.Update(pep);
                    HoursListView.ItemsSource = pep.AllHours;
                    HoursListView.Items.Refresh();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void EventNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HoursTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void ImageRank()
        {
            if (pep.SumHours < 50) { RankLabel.Content = "Unranked"; RankImage.Source = new BitmapImage(new Uri("resources\\UnrankedStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 50 && pep.SumHours <= 200) { RankLabel.Content = "Community"; RankImage.Source = new BitmapImage(new Uri("resources\\CommunityStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 200 && pep.SumHours <= 500) { RankLabel.Content = "Service"; RankImage.Source = new BitmapImage(new Uri("resources\\ServiceStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 500) { RankLabel.Content = "Achievement"; RankImage.Source = new BitmapImage(new Uri("resources\\AchievementStar.png", UriKind.Relative)); }
            var b = Database.People().OrderByDescending(c => c.SumHours).ToList();
            int num = b.FindIndex(po => po.ID == pep.ID) + 1;
            StudentPlacingLabel.Content = ("#" + num);
        }

    }
}
