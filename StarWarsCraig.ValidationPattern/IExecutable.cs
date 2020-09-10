using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsCraig.ValidationPattern
{
    public interface IExecutable<T> : IValidable
    {
        /// <summary>
        /// Executes the algorithm without throwing validation errors.
        /// </summary>
        /// <param name="errors">If it´s not valid, the errors.</param>
        /// <returns>The result of execution</returns>
        T SafeExecute(out IEnumerable<string> errors);

        /// <summary>
        /// Executes the algorithm with throwing validation errors, if they exist.
        /// </summary>
        /// <returns>The result of execution</returns>
        T UnSafeExecute();

        /// <summary>
        /// Executes the algorithm with throwing validation errors, if they exist.
        /// </summary>
        /// <returns>The result of execution</returns>
        Task<T> UnSafeExecuteAsync();
    }
}
