using BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IBookingService
    {
        bool CheckResourceAvailability(BookingModel booking);
        Response BookResource(BookingModel booking);
    }
}
