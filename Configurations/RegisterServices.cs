using PlatformService.Repository.Implementation;
using PlatformService.Repository.Interfaces;
using PlatformService.SyncDataService.Http;

namespace PlatformService.Configurations
{
	public static class RegisterServices
	{
		public static void ServiceRegister(this IServiceCollection services)
		{
			services.AddScoped<IPlatformRepo, PlatformRepo>();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddHttpClient<ICommandDataClient, CommandDataClient>();
		}
	}
}
