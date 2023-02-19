using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VenonatNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venonat";

        public override float commodity => 1f;

        public override PkmnInfo info => VenonatInfo;

        public override int wildLevel => 0;

        public static PkmnInfo VenonatInfo = new PkmnInfo
        {
            Name = "Venonat",
            type1 = PkmnType.bug,
            type2 = PkmnType.poison,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<VenonatPet>(),
            evolveInto = "VenomothNPC",
            evolveAt = 31
        };
    }

    class VenonatPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venonat";
	    public override bool doesFly => false;
    }
}
