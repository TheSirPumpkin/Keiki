using UnityEngine;

namespace Adic
{
    public abstract class BaseAdicMonobehaviour : MonoBehaviour
    {
        public virtual void Start()
        {
            this.Inject();
        }
    }
}
