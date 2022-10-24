using UnityEngine;
using UnityEngine.UIElements;

namespace UI.DAL
{
    [CreateAssetMenu(fileName = "MenuIconsData", menuName = "DAL/MenuIconsData")]
    public class MenuIconsData : ScriptableObject
    {
        public int Id;
        public Sprite Icon;
        public GameObject Prefab;
    }
}
