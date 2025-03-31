using Clubmates.web.Areas.Club.Models;

namespace Clubmates.web.Areas.Club.Services
{
    public interface IClubLayoutService
    {
        public Task<ClubLayout> PopulateClubLayout(string LoggedUserEmail, int clubId);
        public Task<bool> ValidateClub(int? clubId);
        public Task<bool> ValidateClubUser(string? loggedInUserEmail);

    }
}
