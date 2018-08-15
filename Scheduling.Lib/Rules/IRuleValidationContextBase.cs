namespace Scheduling.Lib.Rules
{
    public interface IRuleValidationContextBase<in T> where T : RuleValidatorBase
    {
        void AddRule(T rule);
        bool Validate(IRuleValidationObject validationObject);
    }
}
