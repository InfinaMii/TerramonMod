using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace TerramonMod.Items.Consumable
{
    class WaterStone : BaseEvolveItem
    {
        public override string ItemKey => "WaterStone";
        public override void SetDefaults()
        {
            base.SetDefaults();
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ThunderStone>();
        }
    }
}
