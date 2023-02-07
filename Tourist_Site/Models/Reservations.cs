using System.ComponentModel.DataAnnotations.Schema;

namespace Tourist_Site.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo{ get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        public string ReservationId { get; set; }
        [ForeignKey(nameof(ReservationId))]
        public AppUser ReservationUser { get; set; }

    }
}
