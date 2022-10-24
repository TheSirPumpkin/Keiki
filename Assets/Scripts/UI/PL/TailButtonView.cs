using System.Collections;
using Adic;
using DG.Tweening;
using Services;
using UI.BLL.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PL
{
    public class TailButtonView : ButtonView
    {
        [Inject] private IGameController gameController;

        [SerializeField] private GameObject finger;

        private TailButtonController tailButtonController;

        public override void Start()
        {
            base.Start();

            tailButtonController = GetController<TailButtonController>();

            tailButtonController.SetImage(Id, ref ViewImage);

            gameController.ButtonViews.Add(this);

            gameController.StartPulse += Pulse;
            gameController.EndPulse += ResetState;
        }

        private void OnDestroy()
        {
            gameController.StartPulse -= Pulse;
            gameController.EndPulse -= ResetState;
        }

        public override void DoAction()
        {
            tailButtonController.DoAction();
        }

        public void SetFingerState(bool state)
        {
            finger.SetActive(state);
            finger.transform.parent = state == true ? transform.root : transform;
        }

        private void ResetState()
        {
            DOTween.Kill(transform);
            transform.localScale = Vector3.one;
        }

        private void Pulse()
        {
            transform.localScale = Vector3.one;
            transform.DOScale(1.2f, 0.4f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}