using Spine;
using Spine.PL;
using Spine.Unity;
using UnityEngine;

namespace Services
{
    public interface ISpineController : IService
    {
        void SetAnimation(SkeletonAnimation skeleton, Slot slot, Attachment attachment, string animName, bool loop);
        bool ReturnToMenu { get; set; }
      
    }
}