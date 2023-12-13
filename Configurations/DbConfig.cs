using PlatformService.Data;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Configurations
{
	public static class DbConfig
	{
		public static void ConfigDb(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseInMemoryDatabase("InMemmory");
			});
		}
	}
}
