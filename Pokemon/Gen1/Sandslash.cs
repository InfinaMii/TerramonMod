using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SandslashNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Sandslash";

        public override float commodity => 1f;

        public override PkmnInfo info => SandslashInfo;

        public override int wildLevel => 1;

        public static PkmnInfo SandslashInfo = new PkmnInfo
        {
            Name = "Sandslash",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<SandslashPet>(),
            evolveInto = "SandslashNPC",
            evolveAt = -1
        };
    }

    class SandslashPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Sandslash";
	    public override bool doesFly => false;
    }
}
