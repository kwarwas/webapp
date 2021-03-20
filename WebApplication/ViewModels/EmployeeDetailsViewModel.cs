using System;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }

        public AddressViewModel Address { get; set; }
        
        public EmployeeDetailsViewModel ReportsTo { get; set; }

        public EmployeeDetailsViewModel(Employee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Address = new AddressViewModel(employee.Address, employee.City, employee.Region, employee.PostalCode, employee.Country);
            Title = employee.Title;
            BirthDate = employee.BirthDate;
            HireDate = employee.HireDate;
            TitleOfCourtesy = employee.TitleOfCourtesy;

            if (employee.ReportsToNavigation is null)
                return;

            ReportsTo = new EmployeeDetailsViewModel(employee.ReportsToNavigation);
        }
    }
}