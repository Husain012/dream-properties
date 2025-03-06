using Dream_Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Dream_Properties.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public async Task SaveContactMessageAsync(string name, string email, string subject, string message)
        {
            var parameter = new SqlParameter[]
            {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Subject", subject),
                    new SqlParameter("@Message", message)
                };
            await Database.ExecuteSqlRawAsync("EXEC InsertContactMessage ,@name, @email, @subject, @message", parameter);
        }
    }
}
