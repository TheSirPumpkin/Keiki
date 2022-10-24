using Adic;
using Infrastructure.DAL;
using Services;
using Sounds.BLL;
using Spine.BLL;
using UI.BLL;
using UnityEngine;

namespace Infrastructure.BLL
{
    public class Bootsrapper : ContextRoot
    {
        [SerializeField] private GameObject scriptableObjectsContainer;
        public override void Init()
        {
        }

        public override void SetupContainers()
        {
            Debug.Log("SetupContainers");
            this.AddContainer<InjectionContainer>()
                .RegisterExtension<UnityBindingContainerExtension>()
                .Bind<IGameController>().ToSingleton<GameController>()
                .Bind<ScriptableObjectsContainer>().ToPrefabSingleton(scriptableObjectsContainer)
                .Bind<IGameLoaderController>().ToSingleton<GameLoaderController>()
                .Bind<ILevelCreator>().ToSingleton<LevelCreatorController>()
                .Bind<IButtonController>().ToNamespace("UI.BLL.Buttons")
                .Bind<ISpineController>().ToSingleton<SpineController>()
                .Bind<ISoundController>().ToSingleton<SoundController>()
                ;
        }
    }
}