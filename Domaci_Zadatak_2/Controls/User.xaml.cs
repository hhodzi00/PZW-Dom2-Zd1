using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteImage.MouseDown += (obj, eventHandler) => this.RaiseDeleteEvent();
            this.EditImage.MouseDown += (obj, eventHandler) => this.RaiseEditEvent();

        }







        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
 (
    "Delete", //ime eventa
     RoutingStrategy.Bubble,
     typeof(RoutedEventHandler),
     typeof(User) //tip elementa koji posjeduje event
 );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }



        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
(
 "Edit", //ime eventa
  RoutingStrategy.Bubble,
  typeof(RoutedEventHandler),
  typeof(User) //tip elementa koji posjeduje event
);

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }




        public string Naziv
        {
            get { return (string)GetValue(NazivProperty); }
            set { SetValue(NazivProperty, value); }
        }


        public static readonly DependencyProperty NazivProperty = DependencyProperty.Register
        (
            "Naziv",
            typeof(string),
            typeof(User),
            new UIPropertyMetadata("Naziv")

        );


        public string Put
        {
            get { return (string)GetValue(PutProperty); }
            set { SetValue(PutProperty, value); }
        }

        public static readonly DependencyProperty PutProperty = DependencyProperty.Register
        (
            "Put",
            typeof(string),
            typeof(User),
            new UIPropertyMetadata("/Resources/Images/Unknown_user.png")
        );






    }
}