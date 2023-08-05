using Terraria.GameContent.Creative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TerramonMod.Pokemon;

namespace TerramonMod.Items.Pokeballs
{
    class PokeBallProjectile : BasePkballProjectile
    {
        public override int pokeballCapture => ModContent.ItemType<PokeBallItem>();
        public override float catchModifier => 1;
    }

    class PokeBallItem : BasePkballItem
    {
        public override int pokeballThrow => ModContent.ProjectileType<PokeBallProjectile>();
        public override int igPrice => 200;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault($"Poké Ball");
            // Tooltip.SetDefault("A device for catching wild Pokémon.\nIt is thrown like a ball at the target.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = igPrice / 2; //Amount needed to duplicate them in Journey Mode
        }
    }
}
