using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Display(Name = "Imię")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Data zatrudnienia")]
        public DateTime HireDate { get; set; }
    }
}