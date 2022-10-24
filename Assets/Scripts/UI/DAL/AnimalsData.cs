using UnityEngine;


namespace UI.DAL
{
    [CreateAssetMenu(fileName = "AnimalsData", menuName = "DAL/AnimalsData")]
    public class AnimalsData : ScriptableObject
    {
        public int Id;
        public GameObject Prefab;
    }
}
