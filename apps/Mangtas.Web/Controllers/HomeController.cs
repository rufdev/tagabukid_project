using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;


namespace Mangtas.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IPersonService _personService;
        //private readonly IUnitOfWorkAsync _unitofworkAsync;

        //public HomeController(IPersonService personService, IUnitOfWorkAsync unitofworkAsync)
        //{
        //    _personService = personService;
        //    _unitofworkAsync = unitofworkAsync;
        //}
        
        public async Task<ActionResult> Index()
        {
            //Person person = new Person();

            //person.Name = "RUFINO";
            //person.ObjectState = ObjectState.Added;
            //_personService.Insert(person);
            //await _unitofworkAsync.SaveChangesAsync();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}