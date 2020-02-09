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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiteDB;
using Mairegger.Printing;



namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for AdminAllPeople.xaml
    /// </summary>
    public partial class PAAllStudents : Page
    {
        
        public PAAllStudents()
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
            try
            {
                var selected = (Person)AllStudentsDataGrid.SelectedItem;
                firstNameTextBox.Text = selected.FirstName;
                lastNameTextBox.Text = selected.LastName;
                GradeComboBox.Text = string.Concat(selected.Grade);
                //hoursTextBox.Text = string.Concat(selected.Hours);
                IDTextbox.Text = string.Concat(selected.ID);

                


            }
            catch
            {

            }
            
            
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
                
                Database.Update(selected);
                AllStudentsDataGrid.Items.Refresh();
                MessageBox.Show("Updated");

            }
            catch
            {
                MessageBox.Show("make sure everything is filled out");
            }
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            
            var haha = Database.People();
            var main = Database.People();
            var testlist = from Person in haha  where (Person.Grade == 11) select Person;
            AllStudentsDataGrid.ItemsSource = testlist;



            foreach (Person x in haha)
            {
                var finalList = new List<Person>();


                foreach (Person P in main)
                {
                    if ((bool)NineGradeCheckBox.IsChecked && P.Grade == 9)
                    { finalList.Add(P); }
                    if ((bool)TenGradeCheckBox.IsChecked && P.Grade == 10)
                    { finalList.Add(P); }
                    if ((bool)EleventhGradeCheckBox.IsChecked && P.Grade == 11)
                    { finalList.Add(P); }
                    if ((bool)TwelvthGradeCheckBox.IsChecked && P.Grade == 12)
                    { finalList.Add(P); }
                }
                foreach (Person p in finalList.ToList())
                {
                    if (!(bool)UnrankedCheckBox.IsChecked)
                    {
                        if (p.SumHours < 50) finalList.Remove(p);
                    }
                    if (!(bool)CommunityCheckBox.IsChecked)
                    {
                        if (p.SumHours >= 50 && p.SumHours < 200) finalList.Remove(p);
                    }
                    if (!(bool)ServiceCheckBox.IsChecked)
                    {
                        if (p.SumHours >= 200 && p.SumHours < 500) finalList.Remove(p);
                    }
                    if (!(bool)AchievementCheckBox.IsChecked)
                    {
                        if (p.SumHours >= 500) finalList.Remove(p);
                    }
                }
                AllStudentsDataGrid.ItemsSource = finalList;


            }
        }

        private void AllStudentsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.PropertyName == "AllHours")
            {
                e.Cancel = true;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                

                MessageBoxResult result = MessageBox.Show("Are you sure?","",MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var x = (Person)AllStudentsDataGrid.SelectedItem;
                        string.Concat(Database.Remove(x.ID));
                        AllStudentsDataGrid.ItemsSource = Database.People();
                        break;
                    case MessageBoxResult.No:
                        //MessageBox.Show("ok");
                        break;
                }

            }

            catch (NullReferenceException)
            {
                MessageBox.Show("No option selected");
            }

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {


            var printDialog = new PrintDialog();

            Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

            CustomDataGridDocumentPaginator Pageinator = new CustomDataGridDocumentPaginator(AllStudentsDataGrid, "Printing", pageSize, new Thickness(30, 20, 30, 20));
            printDialog.PrintDocument(Pageinator, "Grid");



        }

    }

}
