using Adic;
using Infrastructure.DAL;
using Services;

namespace UI.PL
{
    public class BackToMenuButtonView : ButtonView
    {
        [Inject] private IGameLoaderController gameLoaderController;
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainer;

        public override void DoAction()
        {
            gameLoaderController.LoadLevelByData(scriptableObjectsContainer.MainMenuLevelData);
        }
    }
}