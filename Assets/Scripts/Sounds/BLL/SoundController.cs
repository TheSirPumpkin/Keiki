using System.Linq;
using Adic;
using Infrastructure.DAL;
using Services;
using UnityEngine;

namespace Sounds.BLL
{
    public class SoundController : ISoundController
    {
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainerPrefab;
        [Inject] private IGameController gameController;

        public void PlaySound(AudioSource audio)
        {
            audio.Stop();
            audio.PlayOneShot(scriptableObjectsContainerPrefab.SoundsData.AnimalSounds
                .FirstOrDefault(i => i.Id == gameController.CurrentAnimalId).NoTailSound);
        }

        public void PlayRandomOkSound(AudioSource audio)
        {
            audio.Stop();
            audio.PlayOneShot(scriptableObjectsContainerPrefab.SoundsData.CorrectAction[
                Random.Range(0, scriptableObjectsContainerPrefab.SoundsData.CorrectAction.Length)]);
        }

        public void PlayRandomBadSound(AudioSource audio)
        {
            audio.Stop();
            audio.PlayOneShot(scriptableObjectsContainerPrefab.SoundsData.IncorrectAction[
                Random.Range(0, scriptableObjectsContainerPrefab.SoundsData.IncorrectAction.Length)]);
        }
    }
}