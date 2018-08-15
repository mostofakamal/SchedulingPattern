using System.Linq;

namespace Scheduling.Lib.Rules.ShiftRules
{
    /// <summary>
    /// The rule: An engineer can do at most one-half day shift in a day.
    /// </summary>
    public class OneShiftPerdayRule : ShiftAssignRuleValidationBase
    {
        protected override bool ValidateRule(IRuleValidationObject validationObject)
        {
            var valObject = (ShiftAssignRuleValidationObject) validationObject;
            return valObject.Engineer.AssignedShifts.All(x => x.Schedule.DayNo != valObject.Shift.Schedule.DayNo);
        }
    }
}