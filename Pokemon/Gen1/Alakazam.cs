using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class AlakazamNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Alakazam";

        public override float commodity => 1f;

        public override PkmnInfo info => AlakazamInfo;

        public override int wildLevel => 1;

        public static PkmnInfo AlakazamInfo = new PkmnInfo
        {
            Name = "Alakazam",
            type1 = PkmnType.psychic,
            type2 = null,
            captureRate = (float)50 / 255,
            petType = ModContent.ProjectileType<AlakazamPet>(),
            evolveInto = "AlakazamNPC",
            evolveAt = 0
        };
    }

    class AlakazamPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Alakazam";
	    public override bool doesFly => false;
    }
}
