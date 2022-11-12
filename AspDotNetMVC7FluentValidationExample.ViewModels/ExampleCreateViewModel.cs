namespace AspDotNetMVC7FluentValidationExample.ViewModels;

public sealed class ExampleCreateViewModel
{
    [Display(Name = "First Line of Address")]
    public string FirstLineOfAddress { get; set; }

    public string PropertyPrice { get; set; }

    [Display(Name = "Currency")]
    public string Currency { get; set; }

    public IEnumerable<SelectListItem> Currencies
    {
        get
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "GBP", Value = "GBP" },
                new SelectListItem { Text = "EUR", Value = "EUR" },
                new SelectListItem { Text = "USD", Value = "USD" },
            };
        }
    }

    [Display(Name = "Description")]
    public string Description { get; set; }
}