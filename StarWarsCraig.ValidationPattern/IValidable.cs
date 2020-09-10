using System.Collections.Generic;

namespace StarWarsCraig.ValidationPattern
{
    public interface IValidable
    {
        /// <summary>
        /// Gets the last result of validation.
        /// </summary>
        /// <returns>The last result of validation.</returns>
        bool IsValid();

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="errors">If it´s not valid, the errors.</param>
        /// <returns>The result of validation.</returns>
        bool Validate(out IEnumerable<string> errors);
    }
}
