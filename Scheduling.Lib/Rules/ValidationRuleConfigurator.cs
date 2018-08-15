using Scheduling.Lib.Rules.AggregateRules;
using Scheduling.Lib.Rules.ShiftRules;

namespace Scheduling.Lib.Rules
{
    /// <summary>
    /// The class for configuring Business rules
    /// </summary>
    public class ValidationRuleConfigurator : IValidationRuleConfigurator
    {
        
        /// <summary>
        /// For configuring shift assigning rules. These rules are mainly applicable when
        /// assigning an employee to a specific shift
        /// </summary>
        /// <returns></returns>
        public RuleValidationContextBase<ShiftAssignRuleValidationBase> ConfigureShiftAssigningRule()
        {
            var context = new RuleValidationContextBase<ShiftAssignRuleValidationBase>();
            context.AddRule(new OneShiftPerdayRule());
            context.AddRule(new NoTwoConsecutiveAfterNoonShiftRule());
            context.AddRule(new TwoDaysExemptionRule());
            return context;
        }

        /// <summary>
        /// For configuring aggregate  schedule rules (e.g. finally after bulding a list of schedule
        /// check if all of the schedules together meets some certain rule which could not be validated earlier
        /// because it needs the whole operation to be finished to validate this kind of rule )
        /// </summary>
        /// <returns></returns>
        public RuleValidationContextBase<AggregateValidationBase> ConfigureAggregateScheduleRule()
        {
            var context = new RuleValidationContextBase<AggregateValidationBase>();
            context.AddRule(new MandatoryOneWholeDaySupportRule());
            return context;
        }


    }
}
