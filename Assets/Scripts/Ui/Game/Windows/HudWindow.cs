using Core.Constants;
using SimpleUi;
using Ui.Game.Hud;

namespace Ui.Game.Windows
{
    public class HudWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.Game.Hud);
        
        protected override void AddControllers()
        {
            AddController<HudController>();
        }
    }
}