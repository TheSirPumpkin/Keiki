using System;
using UI.DAL;
using UnityEngine;

namespace Infrastructure.DAL
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "DAL/LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public int LevelToLoad;
        public GenericDictionary<MenuIconsData, ItemData> Icons;
        public GenericDictionary<AnimalsData, ItemData> Animals;
        public GenericDictionary<GameObject, string> Buttons;
    }
    [Serializable]
    public struct ItemData
    {
        public string ParentName;
        public int Id;
    }
} 
