using BAL.Enum;
using BAL.Helper;
using BAL.Model;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private int getBookedQuantity(DateTime day, IEnumerable<Booking> EffictiveBookingList)
        {
            return EffictiveBookingList.Where(x=>(x.DateFrom<= day && x.DateTo >= day)).Sum(x => x.BookedQuantity);
        }
        public bool CheckResourceAvailability(BookingModel booking)
        {
            var EffictiveBookingList = _unitOfWork.BookingRepository.Get(filter:
                b => ((booking.DateFrom <= b.DateFrom && booking.DateTo >= b.DateFrom)
                    || (booking.DateFrom <= b.DateTo && booking.DateTo <= b.DateTo)
                    || (booking.DateFrom >= b.DateFrom && booking.DateTo <= b.DateTo))
                    &&b.ResourceId==booking.ResourceId);
            int TotalQuantity = _unitOfWork.ResourceRepository.GetById(booking.ResourceId).Quantity;
            for (var day = booking.DateFrom; day.Date <= booking.DateTo; day = day.AddDays(1))
            {
                int availableQuantity = TotalQuantity - getBookedQuantity(day, EffictiveBookingList);
                if (availableQuantity < booking.BookedQuantity)
                {
                    return false;
                }
            }
            return true;
        }
        public Response BookResource(BookingModel booking)
        {
            var Resource = _unitOfWork.ResourceRepository.GetById(booking.ResourceId);
            if (Resource == null)
            {
                return new Response { Status = ResponseStatus.Error, Message = "There is no Resource With this Id", Errors = null, Data = null };

            }
            if (CheckResourceAvailability(booking))
            {
                Booking bookingEntity = new Booking
                {
                    ResourceId = booking.ResourceId,
                    DateFrom = booking.DateFrom,
                    DateTo = booking.DateTo,
                    BookedQuantity = booking.BookedQuantity
                };
                _unitOfWork.BookingRepository.Insert(bookingEntity);
                _unitOfWork.Commit();
                EmailHelper.SendEmail("admin@admin.com", "Booking", $"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {booking.ResourceId}");
                return new Response { Status = ResponseStatus.Success, Message = "Resource has been Booked Successfully", Errors = null, Data = null };
            }
            else
            {
                return new Response { Status = ResponseStatus.Error, Message = "Resource is not Available for This Period of  Time", Errors = null, Data = null};
            }
        }
    }
}
