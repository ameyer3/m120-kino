using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    class Kino
    {
        public string Name { get; set; }
        public int AmountOfSeats { get; set; }
        public IObservable<Film> Filmlist { get; set; }
        private Kino _instance;

        public Kino getInstance()
        {
            return _instance;
        }
        public Film FindFilmByName()
        {
            Film film = new Film();
            return film;
        }
    }
}
