using AutoMapper;
using PlatformService.DTO;
using PlatformService.Models;
using PlatformService.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IPlatformRepo _platformRepo;

		public PlatformsController(IMapper mapper, IPlatformRepo platformRepo)
		{
			_mapper = mapper;
			_platformRepo = platformRepo;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDTO>> GetAllPlatforms()
		{
			var allPlatforms  = _platformRepo.GetAllPlatforms();
		    var platforms  = _mapper.Map<IEnumerable<PlatformReadDTO>>(allPlatforms);
			return Ok(platforms);
		}

		[HttpGet("{id}", Name = "GetPlatformById")]
		public ActionResult<PlatformReadDTO> GetPlatformById(int id)
		{
			var platform =  _platformRepo.GetPlatformById(id);
			if(platform == null)
			{
				return BadRequest();
			}
			return Ok(_mapper.Map<PlatformReadDTO>(platform));
		}

		[HttpPost]
		public ActionResult<PlatformReadDTO> CreatePlatform([FromBody] PlatformCreateDTO platformCreateDTO)
		{
			var platformModel =  _mapper.Map<Platform>(platformCreateDTO);
			_platformRepo.CreatePlatform(platformModel);
			_platformRepo.SaveChanges();

			return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformModel.Id }, platformModel);
		}
	}
}
