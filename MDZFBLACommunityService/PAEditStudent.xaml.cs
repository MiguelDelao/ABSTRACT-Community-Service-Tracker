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
            try
            {
            var h = (Hours)HoursListView.SelectedItem;
            CalendarSelecter.SelectedDate = h.Date;
            HoursTextbox.Text = string.Concat(h.Hour);
            EventNameTextBox.Text = string.Concat(h.Event);
            }
            catch (NullReferenceException) { }


        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string[] a = selectedStudentComboBox.Text.Split(' ');
            pep = Database.FindByName(a[0], a[1]);
            HoursListView.ItemsSource = pep.AllHours;
            FirstNameTextBox.Text = pep.FirstName;
            LastNameTextBox.Text = pep.LastName;
            IDLabel.Content = pep.ID;
            GradeComboBox.Text = string.Concat(pep.Grade);
                ImageRank();
            }
            catch
            {
                MessageBox.Show("Make sure someone is selected");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime z = CalendarSelecter.SelectedDate.Value;
                string y = HoursTextbox.Text;
                string x = EventNameTextBox.Text;
                Hours h = new Hours(double.Parse(y), z, x);
                pep.AddHours(h);
                Database.Update(pep);
                HoursListView.ItemsSource = pep.AllHours;
                HoursListView.Items.Refresh();
                ImageRank();
            }
            catch
            {
                MessageBox.Show("Make sure everything is filled out and in the right format");
            }
            
        }

        private void EventNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateTextBox_Click(object sender, RoutedEventArgs e)
        {

            if (selectedStudentComboBox.SelectedItem == null) MessageBox.Show("Select Somebody First");
            else
            { 
            pep.FirstName = FirstNameTextBox.Text;
            pep.LastName = LastNameTextBox.Text;
            pep.Grade = int.Parse(GradeComboBox.Text);
            Database.Update(pep);
            selectedStudentComboBox.ItemsSource = Database.Names();
            selectedStudentComboBox.Items.Refresh();
                MessageBox.Show("Updated");

            }
            
            
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    try
                    {
                    Hours h = (Hours)HoursListView.SelectedItem;
                    pep.RemoveHours(h);
                    Database.Update(pep);
                    HoursListView.ItemsSource = pep.AllHours;
                    HoursListView.Items.Refresh();
                    
                    }
                    catch { MessageBox.Show("No Event is Selected"); }
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        private void Listviewtest_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void SelectStudentByIDButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                pep = Database.FindByID(int.Parse(selectedStudentID.Text));
                HoursListView.ItemsSource = pep.AllHours;
                FirstNameTextBox.Text = pep.FirstName;
                LastNameTextBox.Text = pep.LastName;
                IDLabel.Content = pep.ID;
                GradeComboBox.Text = string.Concat(pep.Grade);
                ImageRank();
            }
            catch
            {
                MessageBox.Show("Make sure it's in the right format");
            }
        }

        private void SelectedStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
