using System;
using Adic;
using Infrastructure.DAL;
using Services;
using Spine.Unity;


namespace Spine.BLL
{
    public class SpineController : ISpineController
    {
        [Inject] private IGameLoaderController gameLoaderController;
        [Inject] private ScriptableObjectsContainer scriptableObjectsContainerPrefab;
        [Inject] private IGameController gameController;

        public event Action ResetState;
        public bool ReturnToMenu { get; set; }

        private SkeletonAnimation skeleton;
        private Slot slot;


        public void SetAnimation(SkeletonAnimation skeleton, Slot slot, Attachment attachment, string animName, bool loop)
        {
            this.skeleton = skeleton;
            this.slot = slot;

            skeleton.AnimationState.ClearTracks();
            skeleton.skeleton.SetToSetupPose();
            if (animName != null)
            {
                skeleton.AnimationState.SetAnimation(1, animName, loop);
            }

            slot.Attachment = attachment;

            skeleton.AnimationState.Complete += OnUserDefinedEvent;
            skeleton.AnimationState.Complete += (TrackEntry t) => { gameController.ResetTails(); };
        }

        void OnUserDefinedEvent(TrackEntry track)
        {
           
            skeleton.AnimationState.Complete -= OnUserDefinedEvent;
            skeleton.AnimationState.Complete -= (TrackEntry t) => { gameController.ResetTails(); };
            if (!ReturnToMenu)
            {
                SetAnimation(skeleton, slot, null, null, false);
                ResetState?.Invoke();
            }
            else
            {
                gameController.DisableAllTails();
                gameLoaderController.LoadLevelByDataAsync(scriptableObjectsContainerPrefab.MainMenuLevelData);
            }
        }
    }
}