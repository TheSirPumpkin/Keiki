using Adic;
using Services;
using Infrastructure.BLL;
using Infrastructure.DAL;
using UnityEngine;

namespace Infrastructure.PL
{
    public class GameLoader : MonoBehaviour
    {
        public static GameLoader Instance;
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainerPrefab;
        [Inject] private IGameLoaderController gameLoaderController;

        private void Awake()
        {
            if (Instance == null)
            {
                this.Inject();
                Instance = this;

                CheckInitialLevel();

                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void CheckInitialLevel()
        {
            gameLoaderController.LoadLevelByData(scriptableObjectsContainerPrefab.MainMenuLevelData);
        }
    }
}