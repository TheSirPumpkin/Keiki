using System;
using UnityEngine;


namespace Sounds.DAL
{
    [CreateAssetMenu(fileName = "SoundsData", menuName = "DAL/SoundsData")]
    public class SoundsData : ScriptableObject
    {
        public AnimalSpecificSounds[] AnimalSounds;
        public AudioClip[] CorrectAction;
        public AudioClip[] IncorrectAction;

      
    }
[Serializable]
    public struct AnimalSpecificSounds
    {
        public int Id;
        public AudioClip NoTailSound;
    }
}