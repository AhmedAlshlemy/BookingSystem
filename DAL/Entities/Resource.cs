using System.Collections.Generic;

namespace DAL.Entities
{
    public class Resource :BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
