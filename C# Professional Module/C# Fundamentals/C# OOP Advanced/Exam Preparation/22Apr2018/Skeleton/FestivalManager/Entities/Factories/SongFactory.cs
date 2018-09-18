namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

    public class SongFactory : ISongFactory
    {
        public ISong CreateSong(string name, TimeSpan duration)
        {
            Type songType = Assembly
                   .GetCallingAssembly()
                   .GetTypes()
                   .FirstOrDefault(s => s.Name == nameof(Song));

            return (ISong)Activator.CreateInstance(songType, name, duration);
        }
    }
}