using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ParasectNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Parasect";

        public override float commodity => 1f;

        public override PkmnInfo info => ParasectInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ParasectInfo = new PkmnInfo
        {
            Name = "Parasect",
            type1 = PkmnType.bug,
            type2 = PkmnType.grass,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<ParasectPet>(),
            evolveInto = "ParasectNPC",
            evolveAt = -1
        };
    }

    class ParasectPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Parasect";
	    public override bool doesFly => false;
    }
}
