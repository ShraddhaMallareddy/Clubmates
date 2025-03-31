using Microsoft.Identity.Client;

namespace Clubmates.web.Areas.Club.Models
{
    public class ClubLayout
    {
        public List<MainMenu>? mainMenu { get; set; }
        public string? Logo { get; set; }
        public string? ClubName { get; set; }

    }
}
