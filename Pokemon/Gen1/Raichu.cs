using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RaichuNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Raichu";

        public override float commodity => 1f;

        public override PkmnInfo info => RaichuInfo;

        public override int wildLevel => 1;

        public static PkmnInfo RaichuInfo = new PkmnInfo
        {
            Name = "Raichu",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<RaichuPet>(),
            evolutionMethods = null
        };
    }

    class RaichuPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Raichu";
	    public override bool doesFly => false;
    }
}
