using UnityEngine.UI;

namespace Services
{
    public interface IButtonController : IService
    {
        void SetImage(int id, ref Image image);
        void DoAction();
    }
}