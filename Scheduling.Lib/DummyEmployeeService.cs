using System;
using System.Collections.Generic;
using System.Linq;
using Scheduling.Lib.Entities;
using Scheduling.Lib.Utils;

namespace Scheduling.Lib
{
    public class DummyEmployeeService : IEmployeeService
    {
        /// <summary>
        /// Gets the list of Engineers
        /// </summary>
        /// <returns></returns>
        public List<Engineer> GetEngineers()
        {
            return new List<Engineer>()
            {
                new Engineer{Id=1, Name = "Sumon"},
                new Engineer{Id=2, Name = "Habib"},
                new Engineer{Id=3, Name = "Adnan"},
                new Engineer{Id=4, Name = "Reza"},
                new Engineer{Id=5, Name = "Kamal"},
                new Engineer{Id=6, Name = "Shakib"},
                new Engineer{Id=7, Name = "Mostofa"},
                new Engineer{Id=8, Name = "Zahid"},
                new Engineer{Id=9, Name = "Tamim"},
                new Engineer{Id=10, Name = "Rizvi"},
            };
        }

        
    }
}