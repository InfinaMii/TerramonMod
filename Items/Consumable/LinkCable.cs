﻿using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace TerramonMod.Items.Consumable
{
    class LinkCable : BaseEvolveItem
    {
        public override string ItemKey => "LinkCable";

        public override void SetStaticDefaults()
        {
            Item.value = 3000;
        }
    }
}
