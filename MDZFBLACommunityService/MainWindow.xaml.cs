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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
        }

        
        



        private void True_Click(object sender, RoutedEventArgs e)
        {

            Login(UsernameTextBox.Text, PasswordTextBox.Password);
            
        }

        public void Login(string user, string pass)
        {
            if (UsernameTextBox.Text == "admin" && PasswordTextBox.Password == "admin")
            {
                AdminHub ad = new AdminHub();
                ad.Show();
                Close();
                return;
            }

            var pep = Database.People();
            Person log = null;

            foreach(Person p in pep)
            {
               if(p.FirstName.ToLower() == user.ToLower())
                {
                    string pword = p.LastName.ToLower().Substring(0, 2) + p.ID;
                    Console.WriteLine(pword);

                    if(pword == pass)
                    {
                        log = p;
                        

                    }
                }
                
            }

            if (log == null)
            {
                MessageBox.Show("Wrong Password or username");

            }
            else
            {
                StudentView s = new StudentView(log);
                
                s.Show();
                this.Close();

            }
            

        }

        private void AdminSkip_Click(object sender, RoutedEventArgs e)
        {
            AdminHub ad = new AdminHub();
            ad.Show();
            Close();
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Login(UsernameTextBox.Text, PasswordTextBox.Password);
        }

        private void StudentSkip_Click(object sender, RoutedEventArgs e)
        {
            Person log = Database.FindByID(9430);
            StudentView st = new StudentView(log);
            st.Show();
            this.Close();
        }


    }
}
