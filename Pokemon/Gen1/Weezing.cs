using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class WeezingNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weezing";

        public override float commodity => 1f;

        public override PkmnInfo info => WeezingInfo;

        public override int wildLevel => 1;

        public static PkmnInfo WeezingInfo = new PkmnInfo
        {
            Name = "Weezing",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<WeezingPet>(),
            evolveInto = "WeezingNPC",
            evolveAt = -1
        };
    }

    class WeezingPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Weezing";
	    public override bool doesFly => false;
    }
}
