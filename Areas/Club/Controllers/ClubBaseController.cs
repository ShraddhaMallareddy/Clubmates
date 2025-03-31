using Clubmates.web.Areas.Club.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clubmates.web.Areas.Club.Controllers
{
    [Area("Club")]
    [Route("Club/[controller]/[action]")]
    public class ClubBaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["Area"]="Club";
            ViewData["Layout"]="~/Areas/Club/Views/Shared/_ClubLayout.cshtml";

            var mainMenuItem = new List<MainMenu>();


            base.OnActionExecuted(context);
        }
    }
}
