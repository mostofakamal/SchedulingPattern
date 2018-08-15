using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scheduling.Lib;
using Scheduling.Lib.ServiceConfiguration;

namespace Schedular.Tests
{
    [TestClass]
    public class SchedulingTests
    {
        private readonly ISchedularService _schedularService;
        public SchedulingTests()
        {
            var services = new ServiceCollection();
            ServiceConfigurator.Configure(services);
            var serviceProvider = services.BuildServiceProvider();
            _schedularService = serviceProvider.GetService<ISchedularService>();
        }

        [TestMethod]
        public void GenerateSchedule_ScheduleGenerated_OK()
        {
            var schedule = _schedularService.GenerateSchedule();
            Assert.IsTrue(schedule.Any());
            Assert.AreEqual(14, schedule.Count);
        }

        [TestMethod]
        public void GenerateSchedule_NoMore_ThanOne_Shift_A_Day_Per_Engineer()
        {
            var schedule = _schedularService.GenerateSchedule();
            Assert.IsFalse(schedule.Any(x=>x.AfternoonShift.Schedule.DayNo
            == x.MorningShift.Schedule.DayNo && x.MorningShift.EngineerId == x.AfternoonShift.EngineerId));
        }

        [TestMethod]
        public void GenerateSchedule_EachEngineer_HasbeenAssigned_For_AtLeastOneFullDaySupport()
        {
            var schedule = _schedularService.GenerateSchedule();
            Assert.IsTrue(schedule.All(x=>x.AfternoonShift.Engineer.FullDayShiftCount >=1 
            && x.MorningShift.Engineer.FullDayShiftCount >=1));

        }

    }
}
