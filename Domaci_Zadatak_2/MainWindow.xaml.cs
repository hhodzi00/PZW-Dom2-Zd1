
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domaci_Zadatak_2.Controls;

namespace Domaci_Zadatak_2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.RightButton.Click += RightButton_Click;
            this.LeftButton.Click += LeftButton_Click;

          
            Online_User.Delete += OnOnline_UserDelete;
            Online_User.Edit += OnUserEdit;
            

            foreach (var child in this.UserContainer.Children)
            {
               
                var user = child as User;
                user.Delete += OnUserDelete;
                user.Edit += OnUserEdit;
            }


            foreach (var child in this.CommentContainer.Children)
            {
                
                var post = child as Post;
                post.Delete += OnPostDelete;
                post.Edit += OnPostEdit;

            }
        }

        private void OnOnline_UserDelete(object sender, RoutedEventArgs e)
        { 
            var online = sender as User;
            //Neznam kako izbrisati jedan element.. this.Online_User.Remove(online) javlja neku gresku na Remove..// 
           
        }




        private void OnPostEdit(object sender, RoutedEventArgs e)
        {
            var temp = sender as Post;
            temp.Ime = "Unknown";
            temp.Komentar = "not available";
            temp.Put_Post = "/Resources/Images/unknown_user.png";

        }



        private void OnPostDelete(object sender, RoutedEventArgs e)
        {
            var post = sender as Post;
            this.CommentContainer.Children.Remove(post);
        }



        private void OnUserEdit(object sender, RoutedEventArgs e)
        {
            var user = sender as User;
            user.Naziv = "Unknown";
            user.Put = "/Resources/Images/unknown_user.png";
        }



        private void OnUserDelete(object sender, RoutedEventArgs e)
        {
            var user = sender as User;
            this.UserContainer.Children.Remove(user);
        }







        void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User()
            {
                Width = 90,
                Height = 90
            };

            user.Delete += OnUserDelete;
            user.Edit += OnUserEdit;
            this.UserContainer.Children.Add(user);
        }




        void RightButton_Click(object sender, RoutedEventArgs e)
        {
            var post = new Post()
            {
                Height = 80,
                Width = 280
            };

            post.Delete += OnPostDelete;
            post.Edit += OnPostEdit;
            this.CommentContainer.Children.Add(post);
        }








    }
}
