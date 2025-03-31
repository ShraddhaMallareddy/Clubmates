using Microsoft.AspNetCore.Identity;

namespace Clubmates.web.Models
{
    public class ClubmatesUser : IdentityUser
    {
        public string? FullName { get; set; }
        public ClubmatesRole Role { get; set; }
        public ClubmatesProficiency Proficiency { get; set; }
        public string AddressLine1 { get; set; }=string.Empty;
        public string AddressLine2 { get; set; }=string.Empty;
        public string AddressLine3 { get; set; }=string.Empty;
        public string AddressLine4 { get; set; }=string.Empty;
    }
    public enum ClubmatesRole
    {
        User,
        Guest,
        ClubUser,
        ClubAdmin,
        SuperAdmin
    }
    public enum ClubmatesProficiency
    {
        Beginner,
        Intermediate,
        Advanced
    }
}
