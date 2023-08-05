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
    class UltraBallProjectile : BasePkballProjectile
    {
        public override int pokeballCapture => ModContent.ItemType<UltraBallItem>();
        public override float catchModifier => 2f;
    }

    class UltraBallItem : BasePkballItem
    {
        public override int pokeballThrow => ModContent.ProjectileType<UltraBallProjectile>();
        public override int igPrice => 800;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault($"Ultra Ball");
            // Tooltip.SetDefault("An ultra-performance Ball that \npprovides a higher Pokémon catch rate \npthan a Great Ball.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = igPrice / 2; //Amount needed to duplicate them in Journey Mode
        }
    }
}
