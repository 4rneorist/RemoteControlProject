using Microsoft.EntityFrameworkCore;
using RemoteControl.Models.AccountingModels;

namespace RemoteControl.Models
{
    public class RemoteControlContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=root;database=remotecontrol;");
        }

        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
