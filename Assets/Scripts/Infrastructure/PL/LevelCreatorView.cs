using Adic;
using Services;

namespace Infrastructure.PL
{
    public class LevelCreatorView : BaseAdicMonobehaviour
    {
        [Inject]  private ILevelCreator creator;
        public override void Start()
        {
            base.Start();
            
            creator.SpawnElements();
        }
    }
}