using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StarWarsCraig.ValidationPattern
{
    [Serializable]
    public class ValidableException : Exception
    {
        private IEnumerable<string> _errors;

        public override string ToString()
        {
            var formattedErrors = string.Empty;

            if (_errors == null || _errors.Any()) { return base.ToString(); }

            foreach (var error in _errors)
            {
                formattedErrors = string.Format("{0} --- {1}", formattedErrors, error);
            }

            formattedErrors = string.Format("{0} --- {1}", formattedErrors, base.ToString());

            return formattedErrors;
        }

        public ValidableException() : base()
        {
            _errors = new List<string>();
        }

        public ValidableException(IEnumerable<string> errors) : base()
        {
            _errors = errors;
        }

        public ValidableException(string message) : base(message)
        {
        }

        public ValidableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}