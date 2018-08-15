using System.Linq;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib.Rules.ShiftRules
{
    /// <summary>
    /// The rule: An engineer cannot have two afternoon shifts on consecutive days. 
    /// </summary>
    public class NoTwoConsecutiveAfterNoonShiftRule : ShiftAssignRuleValidationBase
    {
        protected override bool ValidateRule(IRuleValidationObject validationObject)
        {
            var valObject = (ShiftAssignRuleValidationObject)validationObject;
            return !(valObject.Shift.ShiftType == ShiftType.Afternoon && valObject.Engineer.AssignedShifts.Any(x =>
                         x.ShiftType == ShiftType.Afternoon && x.Schedule.DayNo == (valObject.Shift.Schedule.DayNo - 1)));
        }
    }
}