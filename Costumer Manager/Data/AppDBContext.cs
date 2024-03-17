using Costumer_Manager.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Costumer_Manager.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options) { }

    public DbSet<CustomerModel> Customers { get; set; }
}
