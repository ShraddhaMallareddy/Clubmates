using Clubmates.web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clubmates.web.NewFolder
{
    public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : IdentityDbContext<ClubmatesUser>(options)
    {
        public DbSet<ClubModel> Clubs { get; set; }
        public DbSet<ClubAccess> ClubAccess { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollResponse> PollResponses { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }

    }
}
