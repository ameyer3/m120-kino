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
        static private Cinema instance;


        static public Cinema GetInstance()
        {
            if (instance == null)
            {
                instance = new Cinema();
            }
            instance.Name = "Kino ABC";
            instance.AmountOfSeats = 85;
            instance.Filmlist = CreateFilmlist();
            return instance;
        }
        public ObservableCollection<Film> FindFilmByName(string searchquery, ObservableCollection<Film> filteredFilmlist)
        {
            IEnumerable<Film> FilteredFilm = Filmlist
                .Where(r => searchquery == null || r.Title.Contains(searchquery))
                .ToList();
            filteredFilmlist = new ObservableCollection<Film>();
            foreach (Film film in FilteredFilm)
            {
                filteredFilmlist.Add(film);
            }
            return filteredFilmlist;
        }
        
        
        static private ObservableCollection<Film> CreateFilmlist()
        {
            Category category1 = new Category(1, "Horror");
            Category category3 = new Category(2, "Comedy");
            Category category2 = new Category(3, "Romance");

            Show show1 = new Show("20:00", 50, 12);
            Show show2 = new Show("12:00", 20, 12);
            Show show3 = new Show("14:25", 15, 12);
            Show show4 = new Show("13:25", 15, 10);
            Show show5 = new Show("12:25", 20, 10);
            Show show6 = new Show("10:25", 50, 5);
            Show show7 = new Show("13:25", 20, 5);

            ObservableCollection<Show> showlist1 = new ObservableCollection<Show> { show1, show2, show3 };
            ObservableCollection<Show> showlist2 = new ObservableCollection<Show> { show4, show5 };
            ObservableCollection<Show> showlist3 = new ObservableCollection<Show> { show6, show7 };

            Film film1 = new Film(1, "Film1", category1, 90, showlist1);
            Film film2 = new Film(2, "Film2", category2, 180, showlist2);
            Film film3 = new Film(3, "Film3", category3, 200, showlist3);
            ObservableCollection<Film> filmlist = new ObservableCollection<Film>{film1, film2, film3};
            return filmlist;
        }
      
    }
}
