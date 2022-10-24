using Infrastructure.DAL;
using UnityEngine;

namespace Services
{
    public interface IGameLoaderController : IService
    {
        void LoadLevelByData(LevelsData level);
        void LoadLevelByDataAsync(LevelsData level);
        LevelsData GetLoadedLevel();
    }
}