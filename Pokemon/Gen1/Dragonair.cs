using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DragonairNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dragonair";

        public override float commodity => 1f;

        public override PkmnInfo info => DragonairInfo;

        public override int wildLevel => 1;

        public static PkmnInfo DragonairInfo = new PkmnInfo
        {
            Name = "Dragonair",
            type1 = PkmnType.dragon,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<DragonairPet>(),
            evolveInto = "DragoniteNPC",
            evolveAt = 55
        };
    }

    class DragonairPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dragonair";
	    public override bool doesFly => false;
    }
}
