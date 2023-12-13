using PlatformService.Models;

namespace PlatformService.Repository.Interfaces
{
	public interface IPlatformRepo
	{
		bool SaveChanges();
		IEnumerable<Platform> GetAllPlatforms();
		Platform GetPlatformById(int id);
		void CreatePlatform(Platform platform);
	}
}
