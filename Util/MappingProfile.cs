using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Core.Models;
using Util.Data.Entities;

namespace Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Firm, FirmDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
