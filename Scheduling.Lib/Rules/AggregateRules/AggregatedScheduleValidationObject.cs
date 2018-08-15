using System.Collections.Generic;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib.Rules.AggregateRules
{
    public class AggregatedScheduleValidationObject : IRuleValidationObject
    {
        public IEnumerable<Engineer> Engineers { get; set; }
    }
}