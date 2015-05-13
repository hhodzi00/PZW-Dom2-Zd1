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

namespace Domaci_Zadatak_2.Controls
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.Edit_Post.MouseDown += (obj, eventHandler) => this.RaiseEditEvent();
            this.Delete_Post.MouseDown += (obj, eventHandler) => this.RaiseDeleteEvent();
        }




        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }




        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
        "Edit", //ime eventa
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }




        public string Ime
        {
            get { return (string)GetValue(ImeProperty); }
            set { SetValue(ImeProperty, value); }
        }

        public static readonly DependencyProperty ImeProperty = DependencyProperty.Register
        (
            "Ime",
            typeof(string),
            typeof(Post),
            new UIPropertyMetadata("Unknown person")
        );

        public string Komentar
        {
            get { return (string)GetValue(KomentarProperty); }
            set { SetValue(KomentarProperty, value); }
        }


        public static readonly DependencyProperty KomentarProperty = DependencyProperty.Register
        (
            "Komentar",
             typeof(string),
             typeof(Post),
             new UIPropertyMetadata("Prazan komentar")
        );


        public string Put_Post
        {
            get { return (string)GetValue(Put_PostProperty); }
            set { SetValue(Put_PostProperty, value); }
        }

        public static readonly DependencyProperty Put_PostProperty = DependencyProperty.Register
        (
            "Put_Post",
            typeof(string),
            typeof(Post),
            new UIPropertyMetadata("/Resources/Images/Unknown_user.png")
        );










    }


}

