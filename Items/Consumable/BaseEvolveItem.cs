using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace TerramonMod.Items.Consumable
{
    abstract class BaseEvolveItem : ModItem
    {
        public virtual string ItemKey => null;
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10; //journey mode dupe amount
        }
        public override void SetDefaults()
        {
            Item.useStyle = 5;// ItemUseStyleID.HoldUp;
            Item.maxStack = 999;
            Item.value = 3000;
            Item.consumable = true;
            Item.UseSound = null;
            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
        }
        public override bool CanUseItem(Player player)
        {
            bool hasPokemon = player.GetModPlayer<TerramonPlayer>().pokeInUse != null;
            if (!hasPokemon)
            {
                Main.NewText("You need to summon your Pokemon to use this item!", Color.Red);
                return false;
            }
            else
            {
                bool canUseStone = player.GetModPlayer<TerramonPlayer>().pokeInUse.data.GetEvolution(ItemKey) != null;
                if (!canUseStone)
                {
                    Main.NewText("This item can't be used on your Pokemon!", Color.Red);
                    return false;
                }
                else
                    return true;
            }
        }

        public override bool? UseItem(Player player) //Manage what happens when the player uses the item
        {
            var pkmn = player.GetModPlayer<TerramonPlayer>().pokeInUse;
            SoundEngine.PlaySound(SoundID.Item29 with { Volume = 0.5f }, player.position);

            pkmn.data.Evolve(ItemKey);
            pkmn.UpdateName();

            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 4);
        }

    }
}
