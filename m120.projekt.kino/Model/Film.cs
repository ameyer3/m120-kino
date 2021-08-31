using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Duration { get; set; }
        public ObservableCollection<Show> Shows { get; set; }
    }
}
