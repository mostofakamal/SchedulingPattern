using System.Linq;
namespace Scheduling.Lib.Rules.AggregateRules
{

    /// <summary>
    /// The rule: Each engineer should have completed one whole day of support 
    /// </summary>
    public class MandatoryOneWholeDaySupportRule : AggregateValidationBase
    {
        protected override bool ValidateRule(IRuleValidationObject validationObject)
        {
            var valObject = (AggregatedScheduleValidationObject) validationObject;
            return !valObject.Engineers.Any(x=>x.FullDayShiftCount < 1);
        }
    }
}
