using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace TerramonMod.Items.Consumable
{
    class ThunderStone : BaseEvolveItem
    {
        public override string ItemKey => "ThunderStone";
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddCustomShimmerResult(ModContent.ItemType<FireStone>())
            .Register();
        }
    }
}
