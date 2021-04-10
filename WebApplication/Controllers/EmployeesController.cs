using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<EmployeesController> _logger;
        
        public EmployeesController(
            NorthwindContext context,
            ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(string searchPhrase)
        {
            IQueryable<Employee> employees = _context.Employees;

            if (!string.IsNullOrWhiteSpace(searchPhrase))
            {
                employees = employees.Where(x => x.LastName.Contains(searchPhrase) || x.City.Contains(searchPhrase));
            }
            
            var vm = new EmployeesViewModel
            {
                Employees = employees.ToArray()
            };
            
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _context.Employees
                .Include(x => x.ReportsToNavigation)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);

            var viewModel = new DetailsEmployeeViewModel(data);
            
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
               return View(viewModel);

            await _context.Employees.AddAsync(new Employee
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                HireDate = viewModel.HireDate
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            
            return View(new EditEmployeeViewModel
            {
                Id = data.EmployeeId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                HireDate = data.HireDate.GetValueOrDefault()
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var data = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == viewModel.Id);

            data.FirstName = viewModel.FirstName;
            data.LastName = viewModel.LastName;
            data.HireDate = viewModel.HireDate;

            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(new DeleteEmployeeViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteEmployeeViewModel viewModel)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == viewModel.Id);

            if (data is null)
                return View(new DeleteEmployeeViewModel(viewModel.Id, "Użytkownik nie istnieje w sytstemie"));

            _context.Employees.Remove(data);

            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}