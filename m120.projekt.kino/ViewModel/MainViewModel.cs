using ch.gibz.m120.carrental.Commands;
using m120.projekt.kino.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Cinema _cinema;
        public string Name { get { return _cinema.Name; } } 
        public int AmountOfSeats { get; set; }
        public ObservableCollection<Film> Filmlist { get { return _cinema.Filmlist; } }

        public ObservableCollection<Film> FilteredFilmlist { get; set; } // now here search always
        public Film SelectedFilm { get; set; }
        //static private Cinema _instance;

        public RelayCommand SeeDetailsCommand { get; private set; }

        public MainViewModel()
        {
            Cinema cinema = Cinema.getInstance();
            _cinema = cinema;

            SeeDetailsCommand = new RelayCommand(SeeFilmDetails);


        }

      


        public void SeeFilmDetails(object o)
        {

            //if (Contacts == null)
            // {
            //     Contacts = new ObservableCollection<ObservableContact>();
            // }
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Title = SelectedFilm.Title;
           
            PurchaseWindow win = new PurchaseWindow(purchaseViewModel);
            win.Show();
        }


    }
}
