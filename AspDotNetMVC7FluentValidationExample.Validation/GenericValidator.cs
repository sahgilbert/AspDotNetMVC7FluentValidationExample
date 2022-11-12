namespace AspDotNetMVC7FluentValidationExample.Validation;

public abstract class GenericValidator<T> : AbstractValidator<T>
{
    protected override bool PreValidate(ValidationContext<T> validationContext, ValidationResult validationResult)
    {
        if (validationContext.InstanceToValidate == null)
        {
            validationResult.Errors.Add(new ValidationFailure("", "Please submit a non-null model"));

            return false;
        }

        return true;
    }

    protected bool IsValidSelectedValue(string selectedValue, IEnumerable<SelectListItem> selectList)
    {
        var selectListItem = selectList
            .Where(x => x.Value == selectedValue)
            .FirstOrDefault();

        if (selectListItem != null && selectListItem.Value == selectedValue)
        {
            return true;
        }

        return false;
    }
}
