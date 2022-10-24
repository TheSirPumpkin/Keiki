using System.Linq;
using Adic;
using Services;
using UI.BLL.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PL
{
    public class MenuButtonView : ButtonView
    {
        [SerializeField] private Image image;
        private MenuButtonController menuButtonController;

        public override void Start()
        {
            base.Start();

            menuButtonController = GetController<MenuButtonController>();

            menuButtonController.SetImage(Id, ref ViewImage);
        }

       public override void DoAction()
        {
            menuButtonController.DoAction();
        }
    }
}