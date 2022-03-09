using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldsmithsFriend_v01.ViewModel
{
    public class MetalTypeViewModel : Model.MetalTypes
    {
        
        
        private ObservableCollection<Model.MetalTypes> _metals;

        public ObservableCollection<Model.MetalTypes> MetalTypes
        {
            get { return _metals; }
            set { _metals = value; }
        }

        

        private Model.MetalTypes _sMetalTypes;

        public Model.MetalTypes SMetalTypes
        {
            get { return _sMetalTypes; }
            set { _sMetalTypes = value;
                NotifyPropertyChanged("SMetalTypes"); 
                }

        }

        
        

       
        
        public MetalTypeViewModel()
        {
            Model.MetalTypes ComboBox1 = new Model.MetalTypes();
            ComboBox1 = _sMetalTypes;
            ComboBox1.MetalType = Text
            
            MetalTypes = new ObservableCollection<Model.MetalTypes>()
            {
                 new Model.MetalTypes(){ Id=3, Name="Fine Silver"}
                ,new Model.MetalTypes(){ Id=1, Name="Sterling Silver"}
                ,new Model.MetalTypes(){ Id=2, Name="12K Yellow Gold"}
                ,new Model.MetalTypes(){ Id=4, Name="14K Yellow Gold"}
                ,new Model.MetalTypes(){ Id=5, Name="14K Nickle White Gold"}
                ,new Model.MetalTypes(){ Id=6, Name="14K Palladium White Gold"}
                ,new Model.MetalTypes(){ Id=7, Name="18K Yellow Gold"}
                ,new Model.MetalTypes(){ Id=8, Name="18K Nickle White Gold"}
                ,new Model.MetalTypes(){ Id=9, Name="18K Palladium White Gold"}
                ,new Model.MetalTypes(){ Id=10, Name="22K Yellow Gold"}
                ,new Model.MetalTypes(){ Id=11, Name="24K Yellow Gold"}
                ,new Model.MetalTypes(){ Id=12, Name="950 Palladium"}
                ,new Model.MetalTypes(){ Id=13, Name="950 Platinum"}

            };
        }

        private string _grams;
        public string Grams
        {

            get { return _grams; }
            set
            {
                double number;
                bool res = double.TryParse(value, out number);
                if (res) _grams = value;
                OnPropertyChanged("Grams");
                OnPropertyChanged("Total");
            }
        }

        private string _markup;

        public string Markup
        {

            get { return _markup; }
            set
            {
                double number;
                bool res = double.TryParse(value, out number);
                if (res) _markup = value;
                OnPropertyChanged("Markup");
                OnPropertyChanged("Total");
            }
        }

        private string _ppg;

        public string Ppg
        {

            get { return MetalType; }

            set { _ppg = value; 
                OnPropertyChanged("MetalType"); }
            
            
        }
       

        private string _total;
        public string Total
        {

            get
            {
                
                if (String.IsNullOrEmpty(MetalType))
                {
                    MetalType = "0";
                }
                if (String.IsNullOrEmpty(Grams))
                {
                    Grams = "0";
                }
                if (string.IsNullOrEmpty(Markup))
                {
                    Markup = "0";
                }
                double res = double.Parse(Grams) * double.Parse(MetalType) * double.Parse(Markup) ;

                return res.ToString();
            }

            
            set
            {
                double res = double.Parse(Grams) * double.Parse(MetalType) * double.Parse(Markup);
                _total = res.ToString();
                OnPropertyChanged("Total");
            }
            
        }

        public new event PropertyChangedEventHandler PropertyChanged;



        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
