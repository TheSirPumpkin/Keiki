using Adic;
using Services;
using UnityEngine.UI;

namespace UI.PL
{
    public class ButtonView : BaseAdicMonobehaviour
    {
        [Inject] public IButtonController[] buttonControllers;
        public Image ViewImage;
        public Button ViewButton;
        public int Id;

        public override void Start()
        {
            base.Start();
            ViewButton.onClick.AddListener(DoAction);
        }

        public virtual T GetController<T>() where  T : class, IButtonController
        {
            foreach (var button in buttonControllers)
            {
                if (button is T)
                {
                    return button as T;
                }
            }
            return null;
        }

        public virtual void OnDestroy()
        {
            ViewButton.onClick.RemoveAllListeners();
        }

        public virtual void DoAction()
        {
        }
    }
}