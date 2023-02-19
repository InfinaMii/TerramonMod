using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TerramonMod.UI
{
    class PartyUI : UIState
    {
        Color color = new Color(50, 255, 153);

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(ModContent.GetTexture("Terraria/UI/ButtonPlay"), new Vector2(Main.screenWidth + 20, Main.screenHeight - 20) / 2f, color);
        }
    }
}
