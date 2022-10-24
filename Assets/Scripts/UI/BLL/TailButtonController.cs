using System.Linq;
using Adic;
using Infrastructure.BLL;
using Infrastructure.DAL;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BLL.Buttons
{
    public class TailButtonController : IButtonController
    {
        [Inject] private IGameLoaderController gameLoaderController;
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainer;
        [Inject] private GameController gameController;
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
            gameController.CheckWinCondition(id);
            gameController.HighlightSelectedTail(id);
        }
    }
}
