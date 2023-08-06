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
    class RareCandy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rare Candy");
            // Tooltip.SetDefault("A candy that is packed with energy.\nIt raises the level of a single Pokémon\nby one.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; //journey mode dupe amount
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
                bool canLevelUp = player.GetModPlayer<TerramonPlayer>().pokeInUse.data.CanLevelUp();
                if (!canLevelUp)
                {
                    Main.NewText("Your Pokemon's level can't get any higher!", Color.Red);
                    return false;
                }
                else
                    return true;
            }
        }

        public override bool? UseItem(Player player) //Manage what happens when the player uses the item
        {
            var pkmn = player.GetModPlayer<TerramonPlayer>().pokeInUse;
            pkmn.data.LevelUp();
            Main.NewText($"{pkmn.data.GetName()} is now Level {pkmn.data.level}!", Color.Yellow);

            if (TerramonMod.fastEvolution)
            {
                if (pkmn.data.Evolve())
                    pkmn.UpdateName();
                else
                    SoundEngine.PlaySound(SoundID.Item29 with { Volume = 0.5f }, player.position);
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item29 with { Volume = 0.5f }, player.position);
                if (pkmn.data.IsEvolveReady())
                    Main.NewText($"{pkmn.data.GetName()} is ready to evolve!", Color.Yellow);
            }

            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 4);
        }

    }
}
