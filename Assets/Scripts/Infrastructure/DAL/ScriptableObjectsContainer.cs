using Sounds.DAL;
using UnityEngine;

namespace Infrastructure.DAL
{
    public class ScriptableObjectsContainer : MonoBehaviour
    {
        [Header("Infrastructure Data")] 
        public LevelsData GameSceneData;
        public LevelsData MainMenuLevelData;

        [Header("Sound Data")] 
        public SoundsData SoundsData;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}