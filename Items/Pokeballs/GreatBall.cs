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
    class GreatBallProjectile : BasePkballProjectile
    {
        public override int pokeballCapture => ModContent.ItemType<GreatBallItem>();
        public override float catchModifier => 1.5f;
    }

    class GreatBallItem : BasePkballItem
    {
        public override int pokeballThrow => ModContent.ProjectileType<GreatBallProjectile>();
        public override int igPrice => 600;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault($"Great Ball");
            // Tooltip.SetDefault("A good, high-performance Ball that\nprovides a higher Pokémon catch rate\nthan a standard Poké Ball.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = igPrice / 2; //Amount needed to duplicate them in Journey Mode
        }
    }
}
