using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01
{
    class SqliteDataAccess
    {
        public static List<Customer> LoadCustomers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Customer>("select * from Customer", new DynamicParameters());
                return output.ToList();
            }

            
        }

        public static List<Project> LoadProjects()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Project>("select * from Project", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SavePerson(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Customer (FirstName, LastName, Street, City, State, Unit, ZipCode, Email, Phone) values (@FirstName, @LastName, @AddressCity, @AddressStreet, @AddressZipCode, @AddressUnit, @AddressZipCode, @Email, @Phone)", customer);
               
            }
        }

        // edit details later : 
        // must connect to correct customer based on name selected
        // must add project with same ID as customer, but new PId and Project Name
        public static void SaveProject(Project project)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Project (Id, PId, ProjectName) values (@Id, @PId, @ProjectName)", project);
            }
        }

        public static void RemovePerson(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Customer where (FirstName, LastName) = (@FirstName, @LastName)", customer);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }
    }
}
