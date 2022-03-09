using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01.Model
{
    public class MetalTypes : PropertyChangedBase
    {
        private string _metalSelected;
        private double _fineSilverSpot = 24.24;
        private double _fineGoldSpot = 1982.3;
        private double _platinumSpot = 1060.5;
        private double _palladiumSpot = 2323.5;
        private string _ppg;
        private double _grams;
        

        public double FineSilverSpot
        {
            get { return _fineSilverSpot; }
            set { _fineSilverSpot = value; }
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // maybe later change ToString format for the $ sign
        
        private string _metalType;
        public string MetalType
        {
            get
            {

                if (_name == "Fine Silver")
                {
                    double res = _fineSilverSpot / 31.1;
                    return Math.Round(res, 2).ToString();

                }
                if (_name == "Sterling Silver")
                {
                    double res = (_fineSilverSpot * .925 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "12K Yellow Gold")
                {
                    double res = (_fineGoldSpot * .5 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "14K Yellow Gold")
                {
                    double res = (_fineGoldSpot * .583 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "14K Nickle White Gold")
                {
                    double res = (_fineGoldSpot * .583 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "14K Palladium White Gold")
                {
                    double res = (_fineGoldSpot * .583 / 31.1 * 1.3);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "18K Yellow Gold")
                {
                    double res = (_fineGoldSpot * .75 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "18K Nickle White Gold")
                {
                    double res = (_fineGoldSpot * .75 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "18K Palladium White Gold")
                {
                    double res = (_fineGoldSpot * .75 / 31.1 * 1.3);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "22K Yellow Gold")
                {
                    double res = (_fineGoldSpot * .9167 / 31.1);
                    return Math.Round(res, 2).ToString();
                    
                }
                if (_name == "24K Yellow Gold")
                {
                    double res = (_fineGoldSpot / 31.1);
                    return Math.Round(res, 2).ToString();
                    
                }
                if (_name == "950 Palladium")
                {
                    double res = (_palladiumSpot * .925 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                if (_name == "950 Platinum")
                {
                    double res = (_platinumSpot * .950 / 31.1);
                    return Math.Round(res, 2).ToString();
                }
                else
                {
                    return "1";
                }


            }

            set { _metalType = value;
                _ppg = value;
                OnPropertyChanged("MetalType"); }
            



        }

        



        
    }
   
}
