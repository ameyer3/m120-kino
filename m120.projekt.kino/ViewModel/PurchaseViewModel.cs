using ch.gibz.m120.carrental.Commands;
using m120.projekt.kino.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

        public RelayCommand BookTicketsCommand { get; }
        public RelayCommand CancelCommand { get; }
        public PurchaseViewModel()
        {
            BookTicketsCommand = new RelayCommand(BookTickets);
            CancelCommand = new RelayCommand(CloseWindow);
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int Duration { get; set; }
        public ObservableCollection<Show> Shows { get; set; }

  
        public Show SelectedShow { get; set;  }
        private int amountTickets;
        public int AmountTickets
        {
            get { return amountTickets; }
            set
            {
                if (value <= 0)
                {
                    amountTickets = 0;
                    TotalPrice = 0;
                    throw new ArgumentException("Book at least one ticket.");
                }
                else if (SelectedShow == null)
                {
                    amountTickets = 0;
                    TotalPrice = 0;
                    throw new ArgumentException("Choose a show first.");   
                }
                else
                {
                    amountTickets = value;
                    RaisePropertyChanged(nameof(AmountTickets));
                    TotalPrice = amountTickets * SelectedShow.Price;
                }
                
            }
        }
        private int totalPrice;
        public int TotalPrice
        {
            get { return totalPrice; }
            set
            {
               
                    totalPrice = 0;
               
                    totalPrice = value;

                
                RaisePropertyChanged(nameof(TotalPrice));
            }
        }
        public void BookTickets(object o)
        {

            if (AmountTickets <= 0 || SelectedShow == null)
            {
                MessageBox.Show("Book at least one ticket and choose a show.");
            }
           
            else
            {
                SelectedShow.AmountFreeSeats -= AmountTickets;
                if (SelectedShow.AmountFreeSeats < 0)
                {
                    SelectedShow.AmountFreeSeats += AmountTickets;
                    MessageBox.Show("This Show is booked out, buy less tickets or choose another time please.");
                }
                else
                {
                    MessageBoxResult dialogResult = MessageBox.Show(
                        "Your reservation has been saved to our system. Would you like to download a receipt?", 
                        "Booking successful!",
                        MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        CreateReceipt(SelectedShow.Time, AmountTickets);
                    }
                    

                    var window = Application.Current.Windows.OfType<Window>()
                        .SingleOrDefault(x => x.IsActive);
                    window.Close();
                }
               


            }
           

        } 
        public void CreateReceipt(string time, int tickets)
        {
            string textFileName = "m120.receipt.cinema.txt";
            StreamWriter sw = new StreamWriter(textFileName);
            sw.WriteLine($"Thanks for choosing our cinema. Your purchase for the movie {Title} has been processed and saved to our system.");
            sw.WriteLine($"You can pick up your {tickets} Tickets at the entry of our cinema. Your total of {TotalPrice}.- will be removed from your credit card in the following days.");
            sw.WriteLine($"Your show starts at {time}. See you then!");
            sw.Close();
            MessageBox.Show("Receipt was saved to your current directory.");
        }

        public void CloseWindow(object o)
        {
            var window = Application.Current.Windows.OfType<Window>()
                        .SingleOrDefault(x => x.IsActive);
            window.Close();
        }


    }
}
