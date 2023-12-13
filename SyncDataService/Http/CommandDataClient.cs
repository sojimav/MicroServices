using PlatformService.DTO;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataService.Http
{
	public class CommandDataClient : ICommandDataClient
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public CommandDataClient(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}

		public async Task SendPlatformToCommand(PlatformReadDTO platformReadDTO)
		{
			var content = new StringContent(JsonSerializer.Serialize(platformReadDTO), Encoding.UTF8, "application/json");
			var response = await  _httpClient.PostAsync(_configuration["CommandService"], content);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("--> Sync POST to CommandService was OK!");
			}
			else
			{
				Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
			}
		}
	}
}
