namespace CommandService.Data
{
    using CommandService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            _ = _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _ = _context.Platforms.Add(platform);
        }

        public bool ExternalPlatformExists(int externalPlatformId) =>
                _context.Platforms.Any(p => p.ExternalId == externalPlatformId);

        public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                 .Where(c => c.PlatformId == platformId && c.Id == commandId)
                 .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandForPlatform(int platformId) =>
            _context.Commands
                    .Where(c => c.PlatformId == platformId)
                    .OrderBy(c => c.Platform.Name);

        public bool PlatformExists(int platformId) =>
                _context.Platforms.Any(p => p.Id == platformId);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
