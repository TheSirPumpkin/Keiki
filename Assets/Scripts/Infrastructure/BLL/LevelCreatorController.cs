using System.Linq;
using Adic;
using Infrastructure.DAL;
using Services;
using Spine.PL;
using UI.PL;
using UnityEngine;

namespace Infrastructure.BLL
{
    public class LevelCreatorController : ILevelCreator
    {
        [Inject] private IGameLoaderController gameLoaderController;
        [Inject] private IGameController gameController;
        private LevelsData level;

        public void SpawnElements()
        {
            level = gameLoaderController.GetLoadedLevel();

            for (int i = 0; i < level.Icons.Count; i++)
            {
                var icon = level.Icons.FirstOrDefault(j => j.Key.Id == i);
                ButtonView button = GameObject .Instantiate(icon.Key.Prefab, GameObject.Find(icon.Value.ParentName).transform).GetComponent<ButtonView>();
                button.Id = icon.Value.Id;
            }

            if (level.Animals.Count > 0)
            {
                var animal = level.Animals.FirstOrDefault(j => j.Key.Id == gameController.CurrentAnimalId);
                var spine = GameObject.Instantiate(animal.Key.Prefab, GameObject.Find(animal.Value.ParentName).transform).GetComponent<SpineView>();
                gameController.SpineView = spine;
            }
            
            if (level.Buttons.Count > 0)
            {
                foreach (var button in level.Buttons)
                {
                    GameObject.Instantiate(button.Key, GameObject.Find(button.Value).transform);
                }
            }
            
        }
    }
}