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
    /// Interaction logic for PSStudentRanking.xaml
    /// </summary>
    public partial class PSStudentRanking : Page
    {
        private Person pep;
        public PSStudentRanking(object p)
        {
            InitializeComponent();
            pep = (Person)p;

            if (pep.SumHours < 50) { RankLabel.Content = "Unranked"; RankImage.Source = new BitmapImage(new Uri("resources\\UnrankedStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 50 && pep.SumHours <= 200) { RankLabel.Content = "Community"; RankImage.Source = new BitmapImage(new Uri("resources\\CommunityStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 200 && pep.SumHours <= 500) { RankLabel.Content = "Service"; RankImage.Source = new BitmapImage(new Uri("resources\\ServiceStar.png", UriKind.Relative)); }
            if (pep.SumHours >= 500) { RankLabel.Content = "Achievement"; RankImage.Source = new BitmapImage(new Uri("resources\\AchievementStar.png", UriKind.Relative)); }
            
            var b = Database.People().OrderByDescending(c => c.SumHours).ToList();
            int num = b.FindIndex(po => po.ID == pep.ID) + 1;
            StudentPlacingLabel.Content = ("#" + num);
            TopFiveStudentsListBox.ItemsSource = b.ToList().GetRange(0, 5);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void test()
        {

        }

        private void TopFiveStudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
