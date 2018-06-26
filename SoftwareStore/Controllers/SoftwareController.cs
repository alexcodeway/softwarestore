using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Services;

namespace SoftwareStore.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        public IActionResult Index()
        {
            var software = _softwareService.GetAll();
            return View(software);
        }

        public IActionResult GetSoftwareGreaterThan(string version)
        {
            // TODO: validate inputs
            var software = _softwareService.GetSoftwareGreaterThan(version);
            return View("Index", software);
        }
    }
}