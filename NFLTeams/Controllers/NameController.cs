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
            ViewBag.NFLSession = _session;

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
            _session.SetUserName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = _session.GetActiveConf(),
                ActiveDiv = _session.GetActiveDiv()
            });
        }
    }
}
