using System.Linq;

namespace Scheduling.Lib.Rules.ShiftRules
{
    /// <summary>
    ///The rule : If an engineer work on two consecutive days are eligible to get two days exemption.
    /// </summary>
    public class TwoDaysExemptionRule : ShiftAssignRuleValidationBase
    {
        protected override bool ValidateRule(IRuleValidationObject validationObject)
        {
            var valObject = (ShiftAssignRuleValidationObject)validationObject;
            var currentShiftDayNo = valObject.Shift.Schedule.DayNo;

            if (valObject.Engineer.AssignedShifts.Count < 2)
            {
                return true;
            }
            // Get all day no of current engineer's all assigned shifts
            var allDayNos = valObject.Engineer.AssignedShifts.Select(x => x.DayNo).OrderByDescending(x=>x).ToList();
            // check if the current schedule will respect the two days exemption rule
            return !(new[] {currentShiftDayNo - 1, currentShiftDayNo - 2}.Contains(allDayNos[0]) ||
                     new[] {currentShiftDayNo - 2, currentShiftDayNo - 3}.Contains(allDayNos[1]));
        }
    }
}
