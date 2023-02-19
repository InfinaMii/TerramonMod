using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SeakingNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seaking";

        public override float commodity => 1f;

        public override PkmnInfo info => SeakingInfo;

        public override int wildLevel => 1;

        public static PkmnInfo SeakingInfo = new PkmnInfo
        {
            Name = "Seaking",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<SeakingPet>(),
            evolveInto = "SeakingNPC",
            evolveAt = -1
        };
    }

    class SeakingPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Seaking";
	    public override bool doesFly => false;
    }
}
