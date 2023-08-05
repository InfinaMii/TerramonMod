using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidokingNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoking";

        public override float commodity => 1f;

        public override PkmnInfo info => NidokingInfo;

        public override int wildLevel => 1;

        public static PkmnInfo NidokingInfo = new PkmnInfo
        {
            Name = "Nidoking",
            type1 = PkmnType.poison,
            type2 = PkmnType.ground,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<NidokingPet>(),
            evolutionMethods = null
        };
    }

    class NidokingPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoking";
	    public override bool doesFly => false;
    }
}
