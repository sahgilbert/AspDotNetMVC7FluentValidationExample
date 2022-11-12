namespace AspDotNetMVC7FluentValidationExample.Controllers;

public class ExampleController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new ExampleCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ExampleCreateViewModel exampleCreateViewModel)
    {
        if (ModelState.IsValid)
        {
            bool successfullyStoredInDatabase = true;

            if (successfullyStoredInDatabase)
            {
                return RedirectToAction("Success", "Example");
            }
            else
            {
                return View("Create", exampleCreateViewModel);
            }
        }

        return View("Create", exampleCreateViewModel);
    }
}



