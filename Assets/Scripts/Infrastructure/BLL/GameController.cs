using System;
using System.Collections.Generic;
using System.Linq;
using Services;
using Spine.PL;
using UI.PL;
using UnityEngine;

namespace Infrastructure.BLL
{
    public class GameController : IGameController
    {
        public int CurrentAnimalId { get; set; }
        public SpineView SpineView { get; set; }
        public bool EndGame { get; private set; }


        public event Action StartPulse;
        public event Action EndPulse;

        private bool sizeChangeLock;
        private List<TailButtonView> buttonViews = new List<TailButtonView>();
        private bool canEnableTails;

        public List<TailButtonView> ButtonViews
        {
            get { return buttonViews; }
            set { buttonViews = value; }
        }

        public void CheckWinCondition(int id)
        {
            EndGame = false;
            if (CurrentAnimalId == id)
            {
                EndGame = true;
                SpineView.SetCorrectTail(id);
            }
            else
            {
                SpineView.SetWrongTail(id);
            }
        }

        public void HighlightSelectedTail(int id)
        {
            canEnableTails = true;
            foreach (var buttonView in ButtonViews)
            {
                buttonView.ViewButton.interactable = false;
                buttonView.transform.localScale = Vector3.one;
            }

            var selectedView = ButtonViews.FirstOrDefault(i => i.Id == id).ViewButton;
            selectedView.transform.localScale = Vector3.one * 1.2f;
        }

        public void ResetTails()
        {
            if (!canEnableTails || EndGame)
                return;
            foreach (var buttonView in ButtonViews)
            {
                buttonView.ViewButton.interactable = true;
                if (!sizeChangeLock)
                    buttonView.transform.localScale = Vector3.one;
            }
        }

        public void DisableAllTails()
        {  
            if (EndGame)
                return;
            
            canEnableTails = false;
            foreach (var buttonView in ButtonViews)
            {
                buttonView.ViewButton.interactable = false;
                if (!sizeChangeLock)
                    buttonView.transform.localScale = Vector3.one;
            }
        }

        public void InvokeStartPulse()
        {
            sizeChangeLock = true;
            StartPulse?.Invoke();
        }

        public void InvokeEndPulse()
        {
            sizeChangeLock = false;
            SetFingerStateFinger(false);
            EndPulse?.Invoke();
        }

        public void SetFingerStateFinger(bool state)
        {
            var button = ButtonViews.FirstOrDefault(i => i.Id == CurrentAnimalId);
            button.SetFingerState(state);
        }
    }
}