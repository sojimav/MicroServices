using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Configurations
{
	public static class PrepDb
	{
		public static void PrepPopulation(this IApplicationBuilder app)
		{
			using (var services = app.ApplicationServices.CreateScope())
			{
				SeedData(services.ServiceProvider.GetService<AppDbContext>());
			}
		}

		private static void SeedData(AppDbContext appDbContext)
		{
			if(!appDbContext.Platforms.Any())
			{
				Console.WriteLine("seeding data to the database!");

				appDbContext.Platforms.AddRange(
					new Platform()
					{
						Name = "Dot Net", Publisher = "Microsoft", Cost = "Free",
					},

					new Platform()
					{
						Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free",
					},
					new Platform()
					{
						Name = "Kubernates", Publisher = "Microsoft",  Cost = "Free"
					}

					);
					appDbContext.SaveChanges();
			}
			else
			{
				Console.WriteLine("Data already exists in the database!");
			}
		}
	}
}
