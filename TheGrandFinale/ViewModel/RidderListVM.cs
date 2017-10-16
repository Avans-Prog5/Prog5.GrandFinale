using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheGrandFinale.ViewModel
{
    public class RidderListVM : ViewModelBase
    {
        public ObservableCollection<RidderVM> Ridders { get; set; }

        public ICommand ShowAdd { get; set; }

        public RidderListVM()
        {
            ShowAdd = new RelayCommand(Add);

            //zelfde als using... soort van
            using (var context = new thegrandfinaleEntities())
            {

                var ridders = context.Ridder.ToList();
                Ridders = new ObservableCollection<RidderVM>(ridders.Select(r => new RidderVM(r)));


            }
        }

        private void Add()
        {
            var window = new AddRidderWindow();
            window.Show();
        }
    }
}
