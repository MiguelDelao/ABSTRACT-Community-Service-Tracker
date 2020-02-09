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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MDZFBLACommunityService
{
    /// <summary>
    /// Interaction logic for PAStatistics.xaml
    /// </summary>
    public partial class PAStatistics : Page
    {
        public PlotModel plt;

        public PAStatistics()
        {
            var peple = Database.People();
            InitializeComponent();
            var b = peple.OrderByDescending(c => c.SumHours);
            var o = peple.OrderBy(c => c.SumHours);
            TopFiveStudentsListBox.ItemsSource = b.ToList().GetRange(0, 5);
            LastFiveStudentsListBox.ItemsSource = o.ToList().GetRange(0, 5);
            plt = new PlotModel();
            plt.Title = "Average Hours Per Grade";



            double nine = peple.Where(fc => fc.Grade == 9).Select(gh => gh.SumHours).Average();
            double ten = peple.Where(fc => fc.Grade == 10).Select(gh => gh.SumHours).Average();
            double eleven = peple.Where(fc => fc.Grade == 11).Select(gh => gh.SumHours).Average();
            double twelve = peple.Where(fc => fc.Grade == 12).Select(gh => gh.SumHours).Average();


            plotview.Model = plt;

            string[] str = { "9th", "10th", "11th", "12th" };



            var barser = new ColumnSeries();
            plt.Series.Add(barser);
            barser.Items.Add(new ColumnItem { Value = nine, Color = OxyColor.Parse("#f1c40f") });
            barser.Items.Add(new ColumnItem { Value = ten, Color = OxyColor.Parse("#7EBDC3") });
            barser.Items.Add(new ColumnItem { Value = eleven, Color = OxyColor.Parse("#D8E4FF") });
            barser.Items.Add(new ColumnItem { Value = twelve, Color = OxyColor.Parse("#31E981") });
            
            plt.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = str,
                IsPanEnabled = false,
                IsZoomEnabled = false,
                Selectable = false,
            });
            

        }



        private void TopFiveStudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LastFiveStudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
