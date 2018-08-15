using Scheduling.Lib.Rules.AggregateRules;
using Scheduling.Lib.Rules.ShiftRules;

namespace Scheduling.Lib.Rules
{
    public interface IValidationRuleConfigurator
    {
        RuleValidationContextBase<ShiftAssignRuleValidationBase> ConfigureShiftAssigningRule();
        RuleValidationContextBase<AggregateValidationBase> ConfigureAggregateScheduleRule();
    }
}