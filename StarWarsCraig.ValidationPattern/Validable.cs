using System.Collections.Generic;

namespace StarWarsCraig.ValidationPattern
{
    public abstract class Validable : IValidable
    {
        protected Validable()
        {
            Validated = false;
        }

        protected bool Validated { get; set; }

        /// <summary>
        /// Gets the last result of validation.
        /// </summary>
        /// <returns>The last result of validation.</returns>
        public bool IsValid()
        {
            return Validated;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="errors">If it´s not valid, the errors.</param>
        /// <returns>The result of validation.</returns>
        public abstract bool Validate(out IEnumerable<string> errors);
    }
}
