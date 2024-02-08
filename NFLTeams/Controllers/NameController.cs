using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        private readonly NFLSession _session;

        public NameController(NFLSession session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            string userName = _session.GetUserName();

            var viewModel = new TeamListViewModel
            {
                UserName = userName,
            };
            return View(viewModel);
        }


        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetUserName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }


        // Add other action methods as needed
    }
}
