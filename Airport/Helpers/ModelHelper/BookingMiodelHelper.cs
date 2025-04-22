using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Helpers.ModelHelper
{
    public static class BookingMiodelHelper
    {
        public static int IdBooking { get; set; }
        public static string BookingCode { get; set; }
        public static DateTime? BookingDate { get; set; }
        public static decimal? TotalPrice { get; set; }
        public static int? IdBookingStatus { get; set; }
    }
}
