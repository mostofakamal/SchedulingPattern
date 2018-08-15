namespace Scheduling.Lib.Rules
{
    /// <summary>
    ///  The base class for Business Rule validator. It is used following Chain of
    /// responsibility design pattern to chain up business rules so that they can be validated
    /// together just like a business rule chain
    /// </summary>
    public abstract class RuleValidatorBase
    {
        /// <summary>
        /// The next validator in the chain
        /// </summary>
        protected RuleValidatorBase NextRuleValidator { get; private set; }

        public bool Validate(IRuleValidationObject validationObject)
        {
            if (ValidateRule(validationObject))
            {
                // If the current validator validates ok then pass 
                // control to next validator in the chain to validate
                if (NextRuleValidator != null)
                {
                    return NextRuleValidator.Validate(validationObject);
                }
                return true;
            }
            return false;
        }
        protected abstract bool ValidateRule(IRuleValidationObject validationObject);

        /// <summary>
        /// Set next validation
        /// </summary>
        /// <param name="nextRule"></param>
        public void SetNextValidationRule(RuleValidatorBase nextRule)
        {
            this.NextRuleValidator = nextRule;
        }
    }
}