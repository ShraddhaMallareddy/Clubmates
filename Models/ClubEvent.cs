using System.ComponentModel.DataAnnotations;

namespace Clubmates.web.Models
{
    public class ClubEvent
    {
        [Key]
        public int Id { get; set; }
        public ClubModel? Club { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public string? EventLocation { get; set; }
        public DateTime? EventStartDateTime { get; set; }
        public DateTime? EventEndDateTime { get; set; }


    }
}
