using System;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class DetailsEmployeeViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public AddressViewModel Address { get; set; }
        public DetailsEmployeeViewModel ReportsTo { get; set; }

        public DetailsEmployeeViewModel(Employee employee)
        {
            Title = employee.Title;
            BirthDate = employee.BirthDate;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            HireDate = employee.HireDate;
            TitleOfCourtesy = employee.TitleOfCourtesy;
            Address = new AddressViewModel(employee.Address, employee.City, employee.Region, employee.PostalCode,
                employee.Country);

            if (employee.ReportsToNavigation is not null)
                ReportsTo = new DetailsEmployeeViewModel(employee.ReportsToNavigation);
        }
    }
}