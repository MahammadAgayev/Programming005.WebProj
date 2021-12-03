using Microsoft.AspNetCore.Mvc;
using Programming005.WebProj.DataAccessLayer;
using Programming005.WebProj.DataAccessLayer.Abstraction;

namespace Programming005.WebProj.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IDatabase DB;

        public BaseController(IDatabase db)
        {
            DB = db;
        }
    }
}
