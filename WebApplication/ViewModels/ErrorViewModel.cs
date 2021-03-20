namespace WebApplication.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

// Ogólnie 
//     dotnet ef dbcontext scaffold "connection-string" -o "destination-folder" provider
//
//     MsSQL
// dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;" -o Models Microsoft.EntityFrameworkCore.SqlServer
//
//     PostgreSQL
// dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=password" -o "Models" Npgsql.EntityFrameworkCore.PostgreSQL
//
//     MySQL
// dotnet ef dbcontext scaffold "Server=localhost;Database=ef;User=root;Password=123456;" "Pomelo.EntityFrameworkCore.MySql"
// dotnet ef dbcontext scaffold "connection-string" -o Models MySql.EntityFrameworkCore
//
