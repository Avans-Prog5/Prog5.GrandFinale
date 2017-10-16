using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheGrandFinale.ViewModel
{
    public class AddRidderVM : ViewModelBase
    {
        public RidderVM Ridder { get; set; }

        public ICommand SaveCommand { get; set; }

        private RidderListVM _ridders;  

        public AddRidderVM(RidderListVM ridders)
        {
            _ridders = ridders;
            Ridder = new RidderVM();
            SaveCommand = new RelayCommand<AddRidderWindow>(Save);
        }

        private void Save(AddRidderWindow obj)
        {

            //eerst toevoegen aan de db

            //zelfde als using... soort van
            using (var context = new thegrandfinaleEntities())
            {
                //optie 1: de add methode aanroepen
                //context.Ridder.Add(Ridder.ToModel());

                //optie 2: attatche
                context.SaveChanges();
            }

            _ridders.Ridders.Add(Ridder);
            obj.Hide();
        }
    }
}
