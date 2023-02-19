using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SandshrewNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Sandshrew";

        public override float commodity => 1f;

        public override PkmnInfo info => SandshrewInfo;

        public override int wildLevel => 0;

        public static PkmnInfo SandshrewInfo = new PkmnInfo
        {
            Name = "Sandshrew",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<SandshrewPet>(),
            evolveInto = "SandslashNPC",
            evolveAt = 22
        };
    }

    class SandshrewPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Sandshrew";
	    public override bool doesFly => false;
    }
}
