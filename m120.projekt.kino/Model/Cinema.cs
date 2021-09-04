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
            _instance.Name = "Kino ABC";
            _instance.AmountOfSeats = 30;
            _instance.Filmlist = CreateFilmlist();
            return _instance;
        }
        public Film FindFilmByName()
        {
            Film film = new Film();
            return film;
        }
        
        
        static private ObservableCollection<Film> CreateFilmlist()
        {
            Category category1 = new Category(1, "Horror");
            Category category3 = new Category(2, "Comedy");
            Category category2 = new Category(3, "Romance");

            Show show1 = new Show("20:00", 50);
            Show show2 = new Show("12:00", 20);
            Show show3 = new Show("13:25", 15);
            ObservableCollection<Show> showlist1 = new ObservableCollection<Show> { show1, show2, show3 };
            ObservableCollection<Show> showlist2 = new ObservableCollection<Show> { show2, show3 };
            ObservableCollection<Show> showlist3 = new ObservableCollection<Show> { show1, show2 };

            Film film1 = new Film(1, "Film1", category1, 90, showlist1);
            Film film2 = new Film(2, "Film2", category2, 180, showlist2);
            Film film3 = new Film(3, "Film3", category1, 200, showlist3);
            ObservableCollection<Film> filmlist = new ObservableCollection<Film>{film1, film2, film3};
            return filmlist;
        }
      
    }
}
