using System;
using System.Collections.Generic;
using System.Linq;
using Scheduling.Lib.Entities;
using Scheduling.Lib.Rules;
using Scheduling.Lib.Rules.AggregateRules;
using Scheduling.Lib.Rules.ShiftRules;
using Scheduling.Lib.Utils;

namespace Scheduling.Lib
{
    /// <summary>
    /// The service responsible for generating the Schedule
    /// </summary>
    public class SchedularService : ISchedularService
    {
        /// <summary>
        /// _employeeService is used for getting dummy data e.g Employee List
        /// _dateService is for getting the schedule dates
        /// _shiftAssigningValidationContext is used for validating the business rule that needs to 
        /// be applied when assigning an engineer to a specific shift
        /// _aggregateValidationContext is used for validating the aggregated result -> the generated schedule list 
        /// _aggregateValidationContext is mainly for those business rules which needs the final result (List of schedule in this case) to be validated 
        /// </summary>
        private readonly IEmployeeService _employeeService;

        private readonly IDateService _dateService;
        private readonly RuleValidationContextBase<ShiftAssignRuleValidationBase> _shiftAssigningValidationContext;
        private readonly RuleValidationContextBase<AggregateValidationBase> _aggregateValidationContext;
        public SchedularService(IEmployeeService employeeService,
            IValidationRuleConfigurator ruleConfigurator, IDateService dateService)
        {
            _employeeService = employeeService;
            _dateService = dateService;
            _shiftAssigningValidationContext = ruleConfigurator.ConfigureShiftAssigningRule();
            _aggregateValidationContext = ruleConfigurator.ConfigureAggregateScheduleRule();
        }

        /// <summary>
        /// Generates the Schedule
        /// </summary>
        /// <returns></returns>
        public List<Schedule> GenerateSchedule()
        {
            List<Engineer> engineers = _employeeService.GetEngineers();

            // Get Scheduling dates 
            var dates = _dateService.GetDatesForScheduling();
            int dayNo = 1;

            var schedules = new List<Schedule>();
            if (!dates.Any() || !engineers.Any())
            {
                return schedules;
            }

            // need to validate the aggregated shift rule to ensure that aggregated rules are validated ok
            // If not then this is not a valid schedule and needs to re-run the process
            while (!_aggregateValidationContext.Validate(new AggregatedScheduleValidationObject { Engineers = engineers }))
            {
                // Need to pull engineer again since the combination of shift assigned to engineer is invalid in terms of aggregate schedule rule
                engineers = _employeeService.GetEngineers(); 
                schedules = BuildSchedules(dates, dayNo, engineers);
            }

            return schedules;
        }

        private List<Schedule> BuildSchedules(IEnumerable<DateTime> dates, int dayNo, List<Engineer> engineers)
        {
            var schedules = new List<Schedule>();
            foreach (var date in dates)
            { 
                var schedule = new Schedule(dayNo, date);
                
                // Schedule for Morning  shift
                AssignEngineerToShift(schedule.MorningShift, engineers);

                // Schedule for AfterNoon shift
                AssignEngineerToShift(schedule.AfternoonShift, engineers);

                schedules.Add(schedule);
                dayNo++;
            }
            return schedules;
        }


        private void AssignEngineerToShift(Shift shift, List<Engineer> engineers)
        {
            var engineer = PickRandomEngineer(engineers);

            // Apply rule to assign shift
            // This shift validation context will apply all the shift rules those are add intoS
            // the shift validation chain to validate if this engineer is eligible to be added to this shift or not
            // If it is not validated ok then exclude that engineer from the list for current shift consideration
            // and pick one from the remaining and then rest of the validation rules applies
            while (!_shiftAssigningValidationContext.Validate(new ShiftAssignRuleValidationObject { Engineer = engineer, Shift = shift }))
            {
                var filteredEngineers = engineers.Where(x => x.Id != engineer.Id).ToList();
                engineer = PickRandomEngineer(filteredEngineers);
            }

            shift.Engineer = engineer;
            shift.EngineerId = engineer.Id;
            engineer.AssignedShifts.Add(shift);
        }

        private Engineer PickRandomEngineer(List<Engineer> engineers)
        {
            return engineers.Shuffle().Take(1).First();
        }
    }
}
