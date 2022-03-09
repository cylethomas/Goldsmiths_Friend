using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GoldsmithsFriend_v01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        

        public MainWindow()
        {

            InitializeComponent();
            Main.Content = new CustomerInput();
            TreeHouse.Content = new TreeHouse();

        }


        private void CustomerInput(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerInput();
            
        }

        public void DisplayCustomer(object sender, RoutedEventArgs e)
        {
            Main.Content = new DisplayCustomer();
        }

        

        

        

        
        






    }       
}

