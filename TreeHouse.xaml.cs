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

namespace GoldsmithsFriend_v01
{
    /// <summary>
    /// Interaction logic for TreeHouse.xaml
    /// </summary>
    public partial class TreeHouse : Page
    {
        List<Project> projects = new List<Project>();
        List<Customer> customers = new List<Customer>();
        public TreeHouse()
        {
            InitializeComponent();
            
            LoadTheTree();
        }

       

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
                    customer.Foreground = Brushes.White;
                    TreeView1.Items.Add(customer);
                    foreach (Project p in projects)
                    {

                        if (p.Id == c.Id && !String.IsNullOrEmpty(p.ProjectName))
                        {
                            TreeViewItem project = new TreeViewItem();
                            project.Header = p.ProjectName;
                            project.Foreground = Brushes.White;
                            customer.Items.Add(project);
                        }
                    }
                }
            }

            
        }
        private void LoadProjectList()
        {
            projects = SqliteDataAccess.LoadProjects();

        }

        private void LoadCustomerList()
        {
            customers = SqliteDataAccess.LoadCustomers();
        }
    }
}
