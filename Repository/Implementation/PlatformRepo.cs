﻿using PlatformService.Data;
using PlatformService.Models;
using PlatformService.Repository.Interfaces;

namespace PlatformService.Repository.Implementation
{
	public class PlatformRepo : IPlatformRepo
	{
		private readonly AppDbContext _appDbContext;

		public PlatformRepo(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void CreatePlatform(Platform platform)
		{
			if(platform == null)
			{
				throw new ArgumentNullException(nameof(platform));
			}

			_appDbContext.Platforms.Add(platform);

		}

		public IEnumerable<Platform> GetAllPlatforms()
		{
			return	_appDbContext.Platforms.ToList();
		}

		public Platform GetPlatformById(int id)
		{
			return _appDbContext.Platforms.FirstOrDefault(row => row.Id == id);
		}

		public bool SaveChanges()
		{
			return _appDbContext.SaveChanges() > 0;
		}
	}
}
