using System;
using System.Collections.Generic;
using Spine.PL;
using UI.PL;

namespace Services
{
    public interface IGameController: IService
    {
        int CurrentAnimalId { get; set; }
        SpineView SpineView { get; set; }
        void CheckWinCondition(int id);
        List<TailButtonView> ButtonViews { get; set; }
        void ResetTails();
        void HighlightSelectedTail(int id);
         void DisableAllTails();
         bool EndGame { get;}
         event Action StartPulse;
         event Action EndPulse;
         void SetFingerStateFinger(bool state);
         void InvokeStartPulse();
         void InvokeEndPulse();
    }
}