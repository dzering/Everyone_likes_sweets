using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}