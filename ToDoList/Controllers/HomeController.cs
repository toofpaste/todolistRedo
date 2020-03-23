using Microsoft.AspNetCore.Mvc;


namespace ToDoList.Controllers
{
    public class Home1 : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
