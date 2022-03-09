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
using System.IO;

namespace GoldsmithsFriend_v01
{
    /// <summary>
    /// Interaction logic for DisplayCustomer.xaml
    /// </summary>
    public partial class DisplayCustomer : Page
    {
        List<Customer> customers = new List<Customer>();
        List<Project> projects = new List<Project>();
        public DisplayCustomer()
        {
            InitializeComponent();
            LoadCustomerList();
            //LoadTheTree();
            
            


        }

        private void WireUpPeopleList()
        {
            List<Customer> customerCheck = new List<Customer>();
            foreach(Customer c in customers)
            {
                if (!String.IsNullOrEmpty(c.FirstName))
                {
                    customerCheck.Add(c);
                }
            }
            listPeopleListBox.ItemsSource = null;
            listPeopleListBox.ItemsSource = customerCheck;
            listPeopleListBox.DisplayMemberPath = "FullName";

        }

        private void removePersonButton_Click(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer();
            if (customers.Contains(listPeopleListBox.SelectedItem))
            {
                c = (Customer)listPeopleListBox.SelectedItem;
                SqliteDataAccess.RemovePerson(c);
            }

        }
        private void LoadCustomerList()
        {
            customers = SqliteDataAccess.LoadCustomers();
            WireUpPeopleList();
        }

        private void LoadProjectList()
        {
            projects = SqliteDataAccess.LoadProjects();
        }


        private void UpdatePersonButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerList();
        }

        /// <summary>
        /// A method that dymanicall loads the tree from the database
        /// and populates the branches
        /// </summary>
        private void LoadTheTree()
        {
            LoadCustomerList();
            LoadProjectList();


            foreach (Customer c in customers)
            {
                if (!String.IsNullOrEmpty(c.FirstName))
                {
                    TreeViewItem customer = new TreeViewItem();
                    customer.Header = c.FullName;
                    TreeView1.Items.Add(customer);
                    foreach (Project p in projects)
                    {

                        if (p.Id == c.Id && !String.IsNullOrEmpty(p.ProjectName))
                        {
                            TreeViewItem project = new TreeViewItem();
                            project.Header = p.ProjectName;
                            customer.Items.Add(project);
                        }
                    }
                }
            }

            /*
            TreeViewItem ParentItem = new TreeViewItem();
            ParentItem.Header = "Parent";
            TreeView1.Items.Add(ParentItem);
            //  
            TreeViewItem Child1Item = new TreeViewItem();
            Child1Item.Header = "Child One";
            ParentItem.Items.Add(Child1Item); // ParentItem up top, added this child to that parent.
            //  
            TreeViewItem Child2Item = new TreeViewItem();
            Child2Item.Header = "Child Two";
            ParentItem.Items.Add(Child2Item);
            TreeViewItem SubChild1Item = new TreeViewItem();
            SubChild1Item.Header = "Sub Child One";
            Child2Item.Items.Add(SubChild1Item);
            TreeViewItem SubChild2Item = new TreeViewItem();
            SubChild2Item.Header = "Sub Child Two";
            Child2Item.Items.Add(SubChild2Item);
            TreeViewItem SubChild3Item = new TreeViewItem();
            SubChild3Item.Header = "Sub Child Three";
            Child2Item.Items.Add(SubChild3Item);
            //  
            TreeViewItem Child3Item = new TreeViewItem();
            Child3Item.Header = "Child Three";
            ParentItem.Items.Add(Child3Item);
            TreeViewItem ParentTwo = new TreeViewItem();
            ParentTwo.Header = "Par 2";
            TreeView1.Items.Add(ParentTwo);
            */
        }

        
    }

    
}

