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
    class MasterBallProjectile : BasePkballProjectile
    {
        public override int pokeballCapture => ModContent.ItemType<MasterBallItem>();
        public override float catchModifier => 2f;
        public override bool CatchPokemonChances(BasePkmn capture, float random) => true;
    }

    class MasterBallItem : BasePkballItem
    {
        public override int pokeballThrow => ModContent.ProjectileType<MasterBallProjectile>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"Master Ball");
            Tooltip.SetDefault("The best Ball with the ultimate \nlevel of performance. It will catch any \nwild Pokémon without fail.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = igPrice / 2; //Amount needed to duplicate them in Journey Mode
        }
    }
}
