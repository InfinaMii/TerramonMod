using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace TerramonMod.Items.Consumable
{
    class WaterStone : BaseEvolveItem
    {
        public override string ItemKey => "WaterStone";
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddCustomShimmerResult(ModContent.ItemType<ThunderStone>())
            .Register();
        }
    }
}
