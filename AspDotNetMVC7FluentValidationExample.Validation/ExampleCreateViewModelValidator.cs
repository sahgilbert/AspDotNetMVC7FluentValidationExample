using FluentValidation;
using FluentValidation.Validators;
using FluentValidation.Results;

namespace AspDotNetMVC7FluentValidationExample.Validation;

public sealed class ExampleCreateViewModelValidator : GenericValidator<ExampleCreateViewModel>
{
    private readonly ExampleCreateViewModel _exampleCreateViewModel;

    public ExampleCreateViewModelValidator()
    {
        _exampleCreateViewModel = new();

        RuleFor(x => x.FirstLineOfAddress)
            .NotEmpty()
            .WithMessage("Please provide the first line of address.")
            .Length(5, 30);

        RuleFor(x => x.PropertyPrice)
            .NotEmpty()
            .WithMessage("Please provide the property price.")
            .Length(5, 30);

        RuleFor(x => x.Currency)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must((objectToValidate, comparisonList) =>
            {
                return IsValidSelectedValue(
                    objectToValidate.Currency,
                    _exampleCreateViewModel.Currencies);
            })
            .WithMessage("Please provide a valid currency.");

        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Please provide a description.")
            .Length(100, 1000)
            .Must(IsValidDescriptionContent)
            .WithMessage("Please provide a valid description.");
    }

    private bool IsValidDescriptionContent(string description)
    {
        if (!String.IsNullOrEmpty(description))
        {
            // TODO: Implement this properly.
            return true;
        }

        return false;
    }
}