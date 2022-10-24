using System.Collections;
using System.Linq;
using Adic;
using Infrastructure.BLL;
using Services;
using Spine;
using Spine.BLL;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.PL
{
    public class SpineView : BaseAdicMonobehaviour
    {
        [Inject] private SpineController spineController;
        [Inject] private ISoundController soundController;
        [Inject] private IGameController gameController;

        [SpineSlot] public string Slot;
        [SpineAttachment()] public string Attachment;
        [SpineAnimation] public string JumpAnim;
        [FormerlySerializedAs("SadAnim")] [SpineAnimation] public string WrongAnim;
        [SpineAnimation] public string StandingTap;
        [SpineAnimation] public string UpsetAnim;
        public TailView[] TailViews;
        
        private SkeletonAnimation skeleton;
        private Slot slot;
        private Attachment Tail;
        private ISkeletonComponent skeletonComponent;
        private AudioSource audio;

        private int wrongAnswers;

        private Coroutine timerRoutine;

        private void Awake()
        {
            skeletonComponent = GetComponent<ISkeletonComponent>();
            skeleton = GetComponent<SkeletonAnimation>();

            slot = skeletonComponent.Skeleton.FindSlot(Slot);
            Tail = skeletonComponent.Skeleton.GetAttachment(Slot, Attachment);
        }

        public override void Start()
        {
            base.Start();
            spineController.SetAnimation(skeleton, slot, null, null,false);
            spineController.ResetState += DisavleTailViews;
            spineController.ResetState += CheckSadAnim;
            audio = GetComponent<AudioSource>();
            soundController.PlaySound(audio);

            StartTimerRoutine();
        }

        private void OnDestroy()
        {
            spineController.ResetState -= DisavleTailViews;
            spineController.ResetState -= CheckSadAnim;
        }

        private void OnMouseDown()
        {
            if(gameController.EndGame)
                return;
            DisavleTailViews();
            spineController.ReturnToMenu = false;
            spineController.SetAnimation(skeleton, slot, null, StandingTap,false);
        }

        public void SetWrongTail(int id)
        {
            StopTimerRoutine();
            wrongAnswers++;
            DisavleTailViews(); 
            TailViews.FirstOrDefault(i => i.Id == id).gameObject.SetActive(true);

            spineController.ReturnToMenu = false;
            spineController.SetAnimation(skeleton, slot, null, WrongAnim, true);
            soundController.PlayRandomBadSound(audio);

            StartTimerRoutine();
        }

        public void SetCorrectTail(int id)
        {
            StopTimerRoutine();
            DisavleTailViews();
            spineController.SetAnimation(skeleton, slot, Tail, JumpAnim,true);
            spineController.ReturnToMenu = true;
            soundController.PlayRandomOkSound(audio);
            
            gameController.InvokeEndPulse();
        }

        public void DisavleTailViews()
        {
            foreach (var tail in TailViews)
            {
                tail.gameObject.SetActive(false);
            }
        }

        private void CheckSadAnim()
        {
            if (wrongAnswers > 2)
            {
                spineController.ReturnToMenu = false;
                spineController.SetAnimation(skeleton, slot, null, UpsetAnim, true);
            }
        }

        private void StopTimerRoutine()
        {
            if (timerRoutine != null)
            {
                StopCoroutine(timerRoutine);
                timerRoutine = null;
            }
        }
        
        private void StartTimerRoutine()
        {
            if (timerRoutine == null)
            {
                timerRoutine =  StartCoroutine(Timer());
            }
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(7);
            gameController.InvokeStartPulse();
            soundController.PlaySound(audio);
            yield return new WaitForSeconds(7);
            gameController.SetFingerStateFinger(true);
            soundController.PlaySound(audio);
        }
    }
}