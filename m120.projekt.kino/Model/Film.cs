using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Duration { get; set; }
        public IObservable<string> Times { get; set; }
        public IObservable<Show> Shows { get; set; }
    }
}
