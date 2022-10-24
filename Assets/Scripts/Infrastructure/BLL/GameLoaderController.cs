using System.Threading.Tasks;
using Adic;
using Services;
using Infrastructure.DAL;
using UnityEngine;

namespace Infrastructure.BLL
{
    public class GameLoaderController : IGameLoaderController
    {
        [Inject] private GameController gameController;
        private LevelsData currentLoadedLevel;
        public void LoadLevelByData(LevelsData level)
        {
            currentLoadedLevel = level;
            if (Application.loadedLevel != currentLoadedLevel.LevelToLoad)
            {
                Application.LoadLevel(currentLoadedLevel.LevelToLoad);
                gameController.ButtonViews.Clear();
            }
        }

        public async void LoadLevelByDataAsync(LevelsData level)
        {
            await Task.Delay(1000);
            LoadLevelByData(level);
        }

        public LevelsData GetLoadedLevel()
        {
            return currentLoadedLevel;
        }
    }
}