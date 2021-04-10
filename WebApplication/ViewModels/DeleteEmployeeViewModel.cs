namespace WebApplication.ViewModels
{
    public class DeleteEmployeeViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public DeleteEmployeeViewModel()
        {
        }

        public DeleteEmployeeViewModel(int id, string message = "")
        {
            Id = id;
            Message = message;
        }
    }
}