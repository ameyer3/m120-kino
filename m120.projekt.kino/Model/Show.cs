using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    public class Show
    {
        public Show() { }
        public Show(string time, int amountFreeSeats, int price)
        {
            Time = time;
            AmountFreeSeats = amountFreeSeats;
            Price = price;
        }
        public string Time { get; set; }
        public int AmountFreeSeats { get; set; }
        public int Price { get; }
    }
}
