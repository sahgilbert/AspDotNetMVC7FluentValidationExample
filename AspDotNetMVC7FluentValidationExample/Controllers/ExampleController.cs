namespace AspDotNetMVC7FluentValidationExample.Controllers;

public class ExampleController : Controller
{
    private readonly IValidator<ExampleCreateViewModel> _validator;

    public ExampleController(IValidator<ExampleCreateViewModel> validator)
    {
        _validator = validator;
    }

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
    public async Task<IActionResult> Create(ExampleCreateViewModel exampleCreateViewModel)
    {
        ValidationResult result = await _validator.ValidateAsync(exampleCreateViewModel);

        if (result.IsValid)
        {
            return RedirectToAction("Success", "Example");
        }
        else
        {
            // Copy the validation results into ModelState.
            // ASP.NET uses the ModelState collection to populate 
            // error messages in the View.
            result.AddToModelState(this.ModelState);

            // re-render the view when validation failed.
            return View("Create", exampleCreateViewModel);
        }
    }

    [HttpGet]
    public ActionResult Success()
    {
        return View();
    }
}