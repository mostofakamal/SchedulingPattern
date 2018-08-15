using Scheduling.Lib.Entities;

namespace Scheduling.Lib.Rules.ShiftRules
{
    public class ShiftAssignRuleValidationObject: IRuleValidationObject
    {
        public Engineer Engineer { get; set; }
        public Shift Shift { get; set; }
    }
}
