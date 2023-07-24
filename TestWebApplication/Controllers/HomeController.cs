using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApplication.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public IActionResult Index()
        {
            //var items = GetAllUsers();
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

       private List<User> GetAllUsers()
        {
            using (IDbConnection connection = Connection)
            {
                return connection.Query<User>("SELECT * FROM User").ToList();
            }
        }
    }
}