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

        private ObservableCollection<Film> filteredFilmlist;
        public ObservableCollection<Film> FilteredFilmlist { get { return filteredFilmlist; } set {
                filteredFilmlist = value;
                RaisePropertyChanged(nameof(FilteredFilmlist));
            } }
        public Film SelectedFilm { get; set; }
        public string Searchquery { get; set; }
        public RelayCommand SeeDetailsCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }

        public MainViewModel()
        {
            Cinema cinema = Cinema.getInstance();
            _cinema = cinema;

            SeeDetailsCommand = new RelayCommand(SeeFilmDetails);
            SearchCommand = new RelayCommand(FindFilmByName);
            FilteredFilmlist = Filmlist;
        }

      


        public void SeeFilmDetails(object o)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Title = SelectedFilm.Title;
            purchaseViewModel.Category = SelectedFilm.Category;
            purchaseViewModel.Duration = SelectedFilm.Duration;
            purchaseViewModel.Shows = SelectedFilm.Shows;
           
            PurchaseWindow win = new PurchaseWindow(purchaseViewModel);
            win.Show();
        }

        public void FindFilmByName(object o)
        {
            IEnumerable<Film> FilteredFilm = Filmlist
                .Where(r => Searchquery == null || r.Title.Contains(Searchquery))
                .ToList();
            //FilteredFilmlist = (ObservableCollection<Film>)FilteredFilm;
            FilteredFilmlist = new ObservableCollection<Film>();
            foreach (Film film in FilteredFilm)
            {
                FilteredFilmlist.Add(film);
            }
        }

        //Get all times in Film class? How to list all times of the shows
        // Loop through the shows of a film, add the thingies and keep the property ig?
        


    }
}
