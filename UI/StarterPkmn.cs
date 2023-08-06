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
using ReLogic.Content;
using TerramonMod.Items;
using TerramonMod.Items.Pokeballs;
using TerramonMod.Pokemon;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;

namespace TerramonMod.UI
{
    class StarterPkmn : UIImageButton
    {
        string pokemon;
        string descriptor;
        UIText text;
        Asset<Texture2D> texture;

        public StarterPkmn(string pokemon, string descriptor, UIText text) : base(ModContent.Request<Texture2D>($"TerramonMod/Minisprites/SidebarSprites/{pokemon}"))
        {
            this.pokemon = pokemon;
            this.descriptor = descriptor;
            this.text = text;
            this.texture = ModContent.Request<Texture2D>($"TerramonMod/Minisprites/mini{pokemon}");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsMouseHovering)
            {
                if (descriptor == null)
                    text.SetText(pokemon);
                else
                    text.SetText($"{pokemon}, the {descriptor} Pokemon");
            }

            Main.LocalPlayer.delayUseItem = IsMouseHovering;
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);

            var newItem = Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_GiftOrReward(), ModContent.ItemType<PokeBallItem>());
            var newPkball = Main.item[newItem].ModItem as BasePkballItem;
            newPkball.SetContents(new PkmnData { pkmn = pokemon + "NPC", level = 5 });

            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem, 1f);

            Main.LocalPlayer.GetModPlayer<TerramonPlayer>().hasChosenStarter = true;
            ModContent.GetInstance<TerramonSystem>().HideStarterUI();
        }
        /*public override void Draw(SpriteBatch spriteBatch)
        {
            var position = new Vector2(HAlign, VAlign);
            spriteBatch.Draw(texture.Value, position, null, Color.White, 0, Vector2.One / 2, 2.5f, SpriteEffects.None, 0);
        }*/
    }
}
