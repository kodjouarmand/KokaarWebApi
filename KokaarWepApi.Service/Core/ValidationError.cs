using System.Collections.Generic;

namespace KokaarWepApi.Service.Core
{
    #region ValidationError
    /// <summary>
    /// This class contains the error message when a validation rule is broken
    /// A validation error object should be created when validating input from the user and 
    /// you want to display a message back to the user.
    /// </summary>
    public class ValidationError
    {
        public ValidationError() { }

        public string ErrorMessage { get; set; }
    }

    #endregion ValidationError

    #region ValidationErrors

    /// <summary>
    /// This class contains a list of validation errors.  This allows you to report back multiple errors.
    /// </summary>
    public class ValidationErrors : List<ValidationError>
    {
        public void Add(string errorMessage)
        {
            base.Add(new ValidationError { ErrorMessage = errorMessage });
        }
    }

    #endregion ValidationErrors
}
