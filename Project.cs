using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01
{
    public class Project : PropertyChangedBase
    {
        private string _metalSelected;
        private double _fineSilverSpot = 24.24;
        private double _fineGoldSpot = 1886.3;
        private double _platinumSpot = 1060.5;
        private double _palladium = 2323.5;
        private double _ppg;
        private int _pMetalOneType;
        

        
        public int Id { get; set; }
        public int PId { get; set; }
        public string ProjectName { get; set; }

       
        




    }
}
