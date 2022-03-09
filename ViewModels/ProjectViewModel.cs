using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01.ViewModel
{
    class ProjectViewModel
    {
        private readonly Project _project = new Project();

        
       
        private ObservableCollection<Project> _selectedProject;
        public ObservableCollection<Project> SelectedProject
        {
            get { return _selectedProject; }
            set { _selectedProject = value; }
        }
        
        public ProjectViewModel()
        {

        }
    }
}
