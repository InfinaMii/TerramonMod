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

namespace TerramonMod.Items.Consumable
{
    class RareCandy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rare Candy");
            Tooltip.SetDefault("A candy that is packed with energy.\nIt raises the level of a single Pokémon\nby one.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; //journey mode dupe amount
        }
        public override void SetDefaults()
        {
            Item.useStyle = 5;// ItemUseStyleID.HoldUp;
            Item.maxStack = 999;
            Item.value = 3000;
            Item.consumable = true;
            Item.UseSound = SoundID.Item30;
            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<TerramonPlayer>().pokeInUse != null)
                return true;
            Main.NewText("You need to summon your Pokemon to use this item!", Color.Red);
            return false;
        }

        public override bool? UseItem(Player player) //Manage what happens when the player uses the item
        {
            var pkmn = player.GetModPlayer<TerramonPlayer>().pokeInUse;
            pkmn.data.LevelUp();
            Main.NewText($"{pkmn.data.GetName()} is now Level {pkmn.data.level}!", Color.Yellow);
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 4);
        }

    }
}
