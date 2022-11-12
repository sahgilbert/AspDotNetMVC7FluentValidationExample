public static class ValidationExtensions
{
    public static void AddToModelState(
        this FluentValidation.Results.ValidationResult result,
        ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}