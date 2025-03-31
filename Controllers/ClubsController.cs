using Clubmates.web.Models;
using Clubmates.web.Models.AdminViewModel;
using Clubmates.web.Models.ClubsViewModel;
using Clubmates.web.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clubmates.web.Controllers
{
    [Authorize(Policy = "MustbeGuest")]
    public class ClubsController(AppIdentityDbContext dbContext, UserManager<ClubmatesUser> userManager) : Controller
    {
        private readonly AppIdentityDbContext _dbContext = dbContext;
        private readonly UserManager<ClubmatesUser> _userManager = userManager;
        public async Task<IActionResult> Index()
        {
            var listOfClubs = await _dbContext
                                    .Clubs
                                    .ToListAsync();

            var listOfClubsViewModel = listOfClubs.Select(club => new CustomerClubViewModel
            {
                ClubId = club.ClubId,
                ClubName = club.ClubName,
                ClubDescription = club.ClubDescription,
                ClubType = club.ClubType,
                ClubRules = club.ClubRules,
                ClubManagerEmail = club.ClubManager?.Email,
                ClubContactNumber = club.ClubContactNumber,
                ClubEmail = club.ClubEmail,
                ClubBackground = club.ClubBackground,
                ClubBanner = club.ClubBanner,
                ClubLogo = club.ClubLogo,
                ClubCategory = club.ClubCategory
            }).ToList();

            return View(listOfClubsViewModel);
        }

        public async Task<IActionResult> ClubDetails(int clubId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var clubDetails = await _dbContext.Clubs.FirstOrDefaultAsync(x => x.ClubId== clubId);
          

            var clubDetailsViewModel = new CustomerClubViewModel()
            {
                ClubBackground = clubDetails?.ClubBackground,
                ClubBanner = clubDetails?.ClubBanner,
                ClubCategory = clubDetails?.ClubCategory?? 0,
                ClubContactNumber = clubDetails?.ClubContactNumber,
                ClubManagerEmail = clubDetails?.ClubManager?.Email,
                ClubDescription = clubDetails?.ClubDescription,
                ClubEmail = clubDetails?.ClubEmail,
                ClubId = clubDetails?.ClubId ?? 0,
                ClubLogo = clubDetails?.ClubLogo,
                ClubName= clubDetails?.ClubName,
                ClubRules = clubDetails?.ClubRules,
                ClubType=clubDetails?.ClubType??0,

            };

            return View(clubDetailsViewModel);


        }
        
        public IActionResult CreateClubForCustomer()
        {

            return View(new CustomerClubViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClubForCustomer(CustomerClubViewModel customerClubViewModel,
                                        IFormFile clubLogo, 
                                        IFormFile clubBanner, 
                                        IFormFile clubBackground)
        {
            if (!ModelState.IsValid)
            {
                return View(customerClubViewModel);
            }
            //who is the logged in user
            var loggedInUserEmail = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            //get that user from database
            if (loggedInUserEmail == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Clubs/CreateClubForCustomer" });
            }
            var loggedInUser = await _userManager.FindByEmailAsync(loggedInUserEmail);
            if (customerClubViewModel != null && loggedInUser != null)
            {
                ClubModel club = new()
                {
                    ClubName = customerClubViewModel.ClubName,
                    ClubDescription = customerClubViewModel.ClubDescription,
                    ClubCategory = customerClubViewModel.ClubCategory,
                    ClubType = customerClubViewModel.ClubType,
                    ClubRules = customerClubViewModel.ClubRules,
                    ClubManager = loggedInUser,
                    ClubContactNumber = customerClubViewModel.ClubContactNumber,
                    ClubEmail = customerClubViewModel.ClubEmail
                };
                if (clubLogo != null)
                {
                    using var memoryStream = new MemoryStream();
                    await clubLogo.CopyToAsync(memoryStream);
                    club.ClubLogo = memoryStream.ToArray();
                }
                if (clubBanner != null)
                {
                    using var memoryStream = new MemoryStream();
                    await clubBanner.CopyToAsync(memoryStream);
                    club.ClubBanner = memoryStream.ToArray();
                }
                if (clubBackground != null)
                {
                    using var memoryStream = new MemoryStream();
                    await clubBackground.CopyToAsync(memoryStream);
                    club.ClubBackground = memoryStream.ToArray();
                }
                var createdClubEntity = _dbContext.Clubs.Add(club);
                await _dbContext.SaveChangesAsync();

                if (createdClubEntity != null)
                {
                    var createdClub = await _dbContext.Clubs.FindAsync(createdClubEntity.Entity.ClubId);
                    if (createdClub != null)
                    {
                        bool isClubRoleAvailable = false;
                        if (await _userManager.GetClaimsAsync(loggedInUser) != null)
                        {
                            var userClaims = await _userManager.GetClaimsAsync(loggedInUser);
                            foreach (var claim in userClaims)
                            {
                                if (claim.Value == Enum.GetName(ClubmatesRole.ClubUser))
                                {
                                    isClubRoleAvailable = true;
                                }
                            }
                            if (!isClubRoleAvailable)
                            {
                                await _userManager
                                            .AddClaimAsync(
                                                    loggedInUser,
                                                    new(ClaimTypes.Role, Enum.GetName(ClubmatesRole.ClubUser) ?? ""));
                            }
                        }
                        loggedInUser.Role = ClubmatesRole.ClubUser;
                        //save the user
                        await _userManager.UpdateAsync(loggedInUser);
                        _dbContext.ClubAccess.Add(new ClubAccess
                        {
                            Club = createdClub,
                            ClubmatesUser = loggedInUser,
                            ClubAccessRole = ClubAccessRole.ClubManager
                        });
                        await _dbContext.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(customerClubViewModel);

        }

        
    }

}

