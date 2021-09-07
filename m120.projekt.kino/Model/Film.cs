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
       
        public Film(int filmId, string title, Category category, int duration, ObservableCollection<Show> shows)
        {
            FilmId = filmId;
            Title = title;
            Category = category;
            Duration = duration;
            Shows = shows;
            Times = GetTimes();
        }
        public int FilmId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Duration { get; set; }
        public ObservableCollection<Show> Shows { get; set; }
        public string Times { get; set; }
        
        public string GetTimes()
        {
            string times = "";
            foreach (Show show in Shows)
            {
                times += show.Time + "\n";
            }
            return times;
        }
    }
}
