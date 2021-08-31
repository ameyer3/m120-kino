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
    public class PurchaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public RelayCommand BookTicketsCommand { get; private set; }
        public PurchaseViewModel()
        {
            BookTicketsCommand = new RelayCommand(BookTickets);
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Duration { get; set; }
        public ObservableCollection<Show> Shows { get; set; }
        
        public Show SelectedShow{get;set;}
        private int amountTickets;
        public int AmountTickets { get { return amountTickets; } set {
                amountTickets = value;
                RaisePropertyChanged(nameof(AmountTickets));
                TotalPrice = amountTickets * 12;
                
            }
        }
        private int totalPrice;
        public int TotalPrice { get { return totalPrice; } set {
                totalPrice = value;
                RaisePropertyChanged(nameof(TotalPrice));
            }
        }
        public void BookTickets(object o)
        {
            if (AmountTickets == 0)
            {
                //or also use datavalidation
                MessageBox.Show("Please choose the amount of Tickets");
            }
            else
            {
                SelectedShow.AmountFreeSeats -= AmountTickets;
                MessageBox.Show(SelectedShow.Time, AmountTickets.ToString() + SelectedShow.AmountFreeSeats.ToString());
                var w = Application.Current.Windows[2];
                w.Hide();
            }

        }
        

    }
}
