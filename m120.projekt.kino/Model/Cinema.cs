using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    class Cinema
    {
        public string Name { get; set; }
        public int AmountOfSeats { get; set; }
        public ObservableCollection<Film> Filmlist { get; set; }
        static private Cinema _instance;


        static public Cinema getInstance()
        {
            if (_instance == null)
            {
                _instance = new Cinema();
            }
            _instance.Name = "Kino Museum";
            _instance.AmountOfSeats = 30;
            _instance.Filmlist = new ObservableCollection<Film>();
            Film film = new Film();
            film.Title = "FIlmtile";
            _instance.Filmlist.Add(film);
            return _instance;
        }
        public Film FindFilmByName()
        {
            Film film = new Film();
            return film;
        }
    }
}
