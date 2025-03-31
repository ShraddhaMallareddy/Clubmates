namespace Clubmates.web.Models
{
    public class ClubAccess
    {
        public int ClubAccessId { get; set; }

        public ClubModel? Club { get; set; }
        public ClubmatesUser? ClubmatesUser { get; set; }

        public ClubAccessRole? ClubAccessRole { get; set; }

    }

    public enum ClubAccessRole 
    { 
        ClubMember,
        ClubManager,
        ClubAdmin
    }

}
