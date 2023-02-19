using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RaticateNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Raticate";

        public override float commodity => 1f;

        public override PkmnInfo info => RaticateInfo;

        public override int wildLevel => 1;

        public static PkmnInfo RaticateInfo = new PkmnInfo
        {
            Name = "Raticate",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)127 / 255,
            petType = ModContent.ProjectileType<RaticatePet>(),
            evolveInto = "RaticateNPC",
            evolveAt = -1
        };
    }

    class RaticatePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Raticate";
	    public override bool doesFly => false;
    }
}
