using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class TangelaNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tangela";

        public override float commodity => 1f;

        public override PkmnInfo info => TangelaInfo;

        public override int wildLevel => 0;

        public static PkmnInfo TangelaInfo = new PkmnInfo
        {
            Name = "Tangela",
            type1 = PkmnType.grass,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<TangelaPet>(),
            evolveInto = "TangrowthNPC",
            evolveAt = 0
        };
    }

    class TangelaPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tangela";
	    public override bool doesFly => false;
    }
}
