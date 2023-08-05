using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerramonMod.UI
{
    class SidebarPkmn : UIHoverImageButton
    {
        ReLogic.Content.Asset<Texture2D> Texture = ModContent.Request<Texture2D>("TerramonMod/empty");
        Vector2 Position;
        bool slotHasPoke = false;

        public SidebarPkmn(Vector2 position) : base(ModContent.Request<Texture2D>("TerramonMod/Minisprites/miniArbok"), "Empty")
        {
            Position = position;
        }

        public override void OnInitialize()
        {
            Top.Set(Position.Y, 0);
            Left.Set(Position.X, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SetImage(Texture);

            var tPlayer = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
            if (tPlayer.pokeInUse != null)
            {
                if (HoverText != tPlayer.pokeInUse.data.GetName())
                {
                    string suffix = tPlayer.pokeInUse.data.isShiny ? "_Shiny" : "";
                    Texture = ModContent.Request<Texture2D>($"TerramonMod/Minisprites/mini{tPlayer.pokeInUse.data.GetInfo().Name}{suffix}");
                    HoverText = tPlayer.pokeInUse.data.GetName();
                }
                slotHasPoke = true;
            }
            else
                slotHasPoke = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (!slotHasPoke)
                color = Color.Transparent;
            else if (IsMouseHovering)
                color = new Color(1, 1, 1, 0.75f);

            spriteBatch.Draw(Texture.Value, Position, null, color, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);
            var player = Main.LocalPlayer.GetModPlayer<TerramonPlayer>();
            if (player.pokeInUse != null)
            {
                player.pokeInUse.data.Nickname = "uiPokeChange";
                player.pokeInUse.UpdateName();
            }
        }
    }
}
