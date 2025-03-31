using System.ComponentModel.DataAnnotations;

namespace Clubmates.web.Models
{
    public class Poll
    {
        [Key]
        public int PollId { get; set; }
        public ClubModel? Club { get; set; }
        public ClubEvent? ClubEvent { get; set; }
        public string? PollQuestion { get; set; }
        public string? PollDescription { get; set; }
        public DateTime? PollStartDateTime { get; set; }
        public DateTime? PollEndDateTime { get; set; }
        public bool? IsMultipleChoice { get; set; }
        public List<PollOption>? PollOptions { get; set; } = [];
    }
}

