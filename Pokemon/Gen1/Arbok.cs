using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ArbokNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Arbok";

        public override float commodity => 1f;

        public override PkmnInfo info => ArbokInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ArbokInfo = new PkmnInfo
        {
            Name = "Arbok",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<ArbokPet>(),
            evolutionMethods = null
        };
    }

    class ArbokPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Arbok";
	    public override bool doesFly => false;
    }
}
