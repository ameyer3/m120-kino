using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace m120.projekt.kino
{
    class TicketConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string strVal = value.ToString();
                if (string.IsNullOrEmpty(strVal))
                {
                    return 0;
                }

                else
                {
                    return int.Parse(strVal);
                }
            }

            catch (Exception)
            {
                return 0;
            }
        }
    }
}
