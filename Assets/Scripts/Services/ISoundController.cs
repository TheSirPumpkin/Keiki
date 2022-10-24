using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface ISoundController : IService
    {
        void PlaySound(AudioSource audio);
        void PlayRandomOkSound(AudioSource audio);
        void PlayRandomBadSound(AudioSource audio);
    }
}