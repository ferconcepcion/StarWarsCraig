using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsCraig.ValidationPattern
{
    public abstract class Executable<T> : Validable, IExecutable<T>
    {
        /// <summary>
        /// Executes algorithm.
        /// </summary>
        /// <returns>The result of execution.</returns>
        protected abstract T Execute();

        /// <summary>
        /// Executes the algorithm with throwing validation errors, if they exist.
        /// </summary>
        /// <returns>The result of execution</returns>
        public T UnSafeExecute()
        {
            if (!IsValid())
            {
                if (Validate(out IEnumerable<string> errors))
                {
                    return Execute();
                }
                throw new ValidableException(errors);
            }

            return Execute();
        }

        /// <summary>
        /// Executes the algorithm with throwing validation errors, if they exist.
        /// </summary>
        /// <returns>The result of execution</returns>
        public Task<T> UnSafeExecuteAsync()
        {
            return Task.Run(() => UnSafeExecute());
        }

        /// <summary>
        /// Executes the algorithm without throwing validation errors.
        /// </summary>
        /// <param name="errors">If it´s not valid, the errors.</param>
        /// <returns>The result of execution</returns>
        public T SafeExecute(out IEnumerable<string> errors)
        {
            errors = new List<string>();
            if (!IsValid())
            {
                if (Validate(out errors))
                {
                    return Execute();
                }
                return default;
            }

            return Execute();
        }
    }
}
