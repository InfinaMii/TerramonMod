﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using TerramonMod.Items.Consumable;
using Terraria.WorldBuilding;
using TerramonMod.Items.Pokeballs;
using Terraria.IO;
using GenUtils;

namespace TerramonMod.Items
{
    public class TerramonItemPass : GenPass
    {
        public TerramonItemPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Scattering candies";
            
            ChestGen.AddChestLoot(ModContent.ItemType<RareCandy>(), ChestID.Gold, minimumStack: 1, maximumStack: 3, chance: 7500);
            ChestGen.AddChestLoot(ModContent.ItemType<RareCandy>(), minimumStack: 1, maximumStack: 2, chance: 3500, excludeDuplicates: true);
            ChestGen.AddChestLoot(ModContent.ItemType<WaterStone>(), ChestID.Water, chance: 8500);
            ChestGen.AddChestLoot(ModContent.ItemType<ThunderStone>(), ChestID.Gold_Locked, chance: 500);
            ChestGen.AddChestLoot(ModContent.ItemType<FireStone>(), ChestID.Shadow_Locked, chance: 1000);
            ChestGen.AddChestLoot(ModContent.ItemType<LeafStone>(), ChestID.LivingTrees, chance: 1500);
            ChestGen.AddChestLoot(ModContent.ItemType<MoonStone>(), ChestID.Gold, chance: 500);

        }
    }

    class ChestLoot : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int potsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Pots"));
            if (potsIndex != -1)
                tasks.Insert(potsIndex + 1, new TerramonItemPass("Terramon Items", 237.4298f));
        }
    }
}
