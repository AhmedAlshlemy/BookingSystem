using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
   public class Booking :BaseEntity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public virtual Resource Resource { get; set; }
    }
}
