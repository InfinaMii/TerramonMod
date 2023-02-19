using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SnorlaxNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Snorlax";

        public override float commodity => 1f;

        public override PkmnInfo info => SnorlaxInfo;

        public override int wildLevel => 1;

        public static PkmnInfo SnorlaxInfo = new PkmnInfo
        {
            Name = "Snorlax",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)25 / 255,
            petType = ModContent.ProjectileType<SnorlaxPet>(),
            evolveInto = "SnorlaxNPC",
            evolveAt = -1
        };
    }

    class SnorlaxPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Snorlax";
	    public override bool doesFly => false;
    }
}
