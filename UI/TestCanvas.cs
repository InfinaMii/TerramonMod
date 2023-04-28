using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerramonMod.UI
{
    class TestCanvas : UIState
    {
        public UIHoverImageButton playButton;

        public override void OnInitialize()
        {
            playButton = new SidebarPkmn(new Vector2(200, 500));

            Append(playButton);
        }
    }
}