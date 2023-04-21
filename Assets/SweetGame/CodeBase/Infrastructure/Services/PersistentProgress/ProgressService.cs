using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public sealed class ProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}