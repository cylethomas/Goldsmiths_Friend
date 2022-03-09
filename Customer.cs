using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01
{
    public class Customer : INotifyPropertyChanged
    {
        
      
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressUnit { get; set; }
        public string Phone { get; set; }

        /*
        public Customer()
        {
            _treeViewCustomers = new ObservableCollection<Customer>();
            
            List<Customer> customers = new List<Customer>();
            customers = SqliteDataAccess.LoadCustomers();
            foreach(Customer c in customers)
            {
                _treeViewCustomers.Add(c);
            }
           

        } 
        */
        

        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        }



    }
}
