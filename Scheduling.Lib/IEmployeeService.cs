using System.Collections.Generic;
using Scheduling.Lib.Entities;

namespace Scheduling.Lib
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets the list of Engineers
        /// </summary>
        /// <returns></returns>
        List<Engineer> GetEngineers();
    }
}
