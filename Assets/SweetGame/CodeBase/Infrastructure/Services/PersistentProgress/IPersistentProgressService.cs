using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}