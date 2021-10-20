using System;

namespace BAL.Model
{
    public class BookingModel : BaseModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
    }
}
