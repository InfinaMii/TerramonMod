using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace TerramonMod.Items.Consumable
{
	class FireStone : BaseEvolveItem
	{
		public override string ItemKey => "FireStone";
		public override void AddRecipes()
		{
			var recipe = CreateRecipe();
			recipe.AddCustomShimmerResult(ModContent.ItemType<WaterStone>());
			recipe.DisableRecipe();
			recipe.Register();
		}
	}
}
