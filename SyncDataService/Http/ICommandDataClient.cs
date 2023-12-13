using PlatformService.DTO;

namespace PlatformService.SyncDataService.Http
{
	public interface ICommandDataClient
	{
		Task SendPlatformToCommand(PlatformReadDTO platformReadDTO);
	}
}
