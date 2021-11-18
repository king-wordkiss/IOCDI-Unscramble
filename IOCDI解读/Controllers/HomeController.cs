using IOCDIIBLL;
using IOCDIIDAL;
using IOCDI解读.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IOCDI解读.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDAL _iUserDAL;
        private readonly IUserBLL _iUserBLL;

        public HomeController(ILogger<HomeController> logger , IUserDAL userDAL , IUserBLL userBLL)
        {
            _logger = logger;
            _iUserDAL = userDAL;
            _iUserBLL = userBLL;
        }

        public IActionResult Index()
        {
           var model =   this._iUserBLL.Login("123");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
