﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Core.Models;

namespace Util.Core.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeesFromFile(string path);

    }
}
