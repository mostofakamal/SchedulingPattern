using System.Collections.Generic;
using System.Linq;

namespace Scheduling.Lib.Rules
{
    /// <summary>
    /// The base class for Business rule validation context, entry point for adding rules to the chain
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RuleValidationContextBase<T> : IRuleValidationContextBase<T> where T : RuleValidatorBase
    {
        private readonly IList<T> _validators = new List<T>();

        public void AddRule(T rule)
        {
            if (_validators.Any())
            {
                _validators.Last().SetNextValidationRule(rule);
            }
            _validators.Add(rule);
        }

        public bool Validate(IRuleValidationObject validationObject)
        {
            if (!_validators.Any())
            {
                // No validators to validate , so return true
                return true;
            }
            return _validators.First().Validate(validationObject);

        }
    }
}