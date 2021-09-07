using ch.gibz.m120.carrental.Commands;
using m120.projekt.kino.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        private Cinema cinema;
        public string Name { get { return cinema.Name; } }
        public ObservableCollection<Film> Filmlist { get { return cinema.Filmlist; } }

        private ObservableCollection<Film> filteredFilmlist;
        public ObservableCollection<Film> FilteredFilmlist
        {
            get { return filteredFilmlist; }
            set
            {
                filteredFilmlist = value;
                RaisePropertyChanged(nameof(FilteredFilmlist));
            }
        }
        public Film SelectedFilm { get; set; }
        public string Searchquery { get; set; }


        public RelayCommand SeeDetailsCommand { get; }
        public RelayCommand SearchCommand { get; }
        public RelayCommand SeeAllFilmsCommand { get; }

        public MainViewModel()
        {
            Cinema cinemaInstance = Cinema.GetInstance();
            cinema = cinemaInstance;

            SeeDetailsCommand = new RelayCommand(SeeFilmDetails);
            SearchCommand = new RelayCommand(FindFilmByName);
            SeeAllFilmsCommand = new RelayCommand(SeeAllFilms);

            FilteredFilmlist = Filmlist;
        }


        /// <summary>
        /// open the other window "PurchaseWindow" to see Details about the film and book tickets
        /// </summary>
        /// <param name="o"></param>
        public void SeeFilmDetails(object o)
        {
            if (SelectedFilm != null)
            {
                PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
                purchaseViewModel.Title = SelectedFilm.Title;
                purchaseViewModel.Category = SelectedFilm.Category;
                purchaseViewModel.Duration = SelectedFilm.Duration;
                purchaseViewModel.Shows = SelectedFilm.Shows;

                PurchaseWindow win = new PurchaseWindow(purchaseViewModel);
                win.Show();
            }
            else
            {
                MessageBox.Show("Please select a movie.");
            }

        }

        public void FindFilmByName(object o)
        {
            FilteredFilmlist = cinema.FindFilmByName(Searchquery, FilteredFilmlist);
        }

        public void SeeAllFilms(object o)
        {
            FilteredFilmlist = Filmlist;
        }
    }
}
