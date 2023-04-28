using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerramonMod.UI
{
    class UIHoverImageButton : UIImageButton
    {
        internal string HoverText;
        internal Vector2 drawPosition;
        public UIHoverImageButton(ReLogic.Content.Asset<Texture2D> texture, string hoverText) : base(texture)
        {
            HoverText = hoverText;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (isHover)
                Main.LocalPlayer.mouseInterface = true;
        }

        bool isHover = false;
        //bool origUseState = false;

        public override void MouseOver(UIMouseEvent evt)
        {
            isHover = true;
            //origUseState = Main.LocalPlayer.delayUseItem;
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            isHover = false;
            //Main.LocalPlayer.delayUseItem = origUseState;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (IsMouseHovering)
            {
                Main.hoverItemName = HoverText;
            }
        }
    }
}