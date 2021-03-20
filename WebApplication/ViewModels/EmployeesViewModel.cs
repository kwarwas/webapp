using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class EmployeesViewModel
    {
        public ICollection<Employee> Employees { get; set; }
        public string SearchPhrase { get; set; }
    }
}