using Bai4.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai4.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Category> Categories {  get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<NavItem> NavItems { get; set; }

	}
}
