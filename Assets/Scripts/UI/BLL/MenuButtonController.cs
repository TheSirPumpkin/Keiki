using System.Linq;
using Adic;
using Infrastructure.DAL;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BLL.Buttons
{
    public class MenuButtonController : IButtonController
    {
        [Inject] private IGameLoaderController gameLoaderController;
        [Inject] private IGameController gameController;
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainer;
        private LevelsData level;
        private int id;

        public void SetImage(int id, ref Image image)
        {
            this.id = id;
            level = gameLoaderController.GetLoadedLevel();
            var icon = level.Icons.FirstOrDefault(j => j.Key.Id == this.id);
            image.sprite = icon.Key.Icon;
        }

        public void DoAction()
        {
            gameController.CurrentAnimalId = id;
            gameLoaderController.LoadLevelByData(scriptableObjectsContainer.GameSceneData);
        }
    }
}
