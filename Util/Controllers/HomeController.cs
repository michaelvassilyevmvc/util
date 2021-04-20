using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Util.Models;
using Util.Core;
using Util.Core.Repositories;
using Util.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Util.Core.Models;

namespace Util.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _context;
        

        public HomeController(IEmployeeRepository employeeRepository, ApplicationDbContext context,ILogger<HomeController> logger, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._context = context;
        }

        public IActionResult Index()
        {
            var firms = this._context.Firms.AsNoTracking().ToList();
            

            var model = _mapper.Map<IEnumerable<FirmDTO>>(firms);
            return View(model);
        }

        public IActionResult Employee()
        {
            var employees = this._context.Employees.ToList();
            var newEmploees = this._employeeRepository.GetEmployeesFromFile(@"c:\test.docx");

            var model = this._mapper.Map<IEnumerable<EmployeeDTO>>(newEmploees);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
