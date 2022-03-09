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
    /// Interaction logic for CustomerInput.xaml
    /// </summary>
    public partial class CustomerInput : Page
    {
        

        List<Customer> customers = new List<Customer>();    
        
            public CustomerInput()
            {
                Model.MetalTypes ComboBoxOne = new Model.MetalTypes();
                InitializeComponent();
                ComboBoxOne.MetalType = TextBoxPpg1.Text;
            

                
                // we run routines here for the page
                // updates from button clicks and loading what we want
                // from our SQLiteDataAccess

                
            }

        public object Main { get; private set; }

        private void addNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            //rename this method 

            
            Customer c = new Customer();
            Project p = new Project();

            c.FirstName = firstNameText.Text;
            c.LastName = lastNameText.Text;
            c.AddressCity = cityText.Text;
            c.AddressStreet = streetText.Text;
            c.AddressState = stateText.Text;
            c.AddressZipCode = zipCodeText.Text;
            c.AddressUnit = unitText.Text;
            c.Email = emailText.Text;
            c.Phone = phoneText.Text;
            // Save customer c to load it into the new list
            SqliteDataAccess.SavePerson(c);
            

            // load customer list from DB
            LoadCustomerList();

            // get customer ID from list, because it was populated in DB
            foreach(Customer d in customers)
            {
                if(d.FirstName == c.FirstName && d.LastName == c.LastName)
                {
                    p.Id = d.Id;
                    p.PId = p.Id;
                    // fix problem later where two people have the same first and last name
                }
            }
                        
            p.ProjectName = textBoxProjectName.Text;

            //Send Project to Database
            SqliteDataAccess.SaveProject(p);

            //we update the two pages TreeNavigation, and Customer Input
            var mainWindow = GetParentWindow(this);
            if (mainWindow != null) mainWindow.Main.Navigate(new CustomerInput());
            if (mainWindow != null) mainWindow.TreeHouse.Navigate(new TreeHouse());



            ResetText();

        }

        private void LoadCustomerList()
        {
            customers = SqliteDataAccess.LoadCustomers();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// This method resets all text input fields on the customer input page
        /// </summary>
        private void ResetText()
        {
            firstNameText.Text = "";
            lastNameText.Text = "";

            textBoxProjectName.Text = "";
        }

        

        private void TreeHouseTest_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = GetParentWindow(this);
            if (mainWindow != null) mainWindow.Main.Navigate(new CustomerInput());
            new MainWindow();
        }

        private static MainWindow GetParentWindow(DependencyObject obj)
        {
            while (obj != null)
            {
                var mainWindow = obj as MainWindow;
                if (mainWindow != null) return mainWindow;
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
