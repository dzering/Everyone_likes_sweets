using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public sealed class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}