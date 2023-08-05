using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MagnetonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magneton";

        public override float commodity => 1f;

        public override PkmnInfo info => MagnetonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MagnetonInfo = new PkmnInfo
        {
            Name = "Magneton",
            type1 = PkmnType.electric,
            type2 = PkmnType.steel,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<MagnetonPet>(),
            evolutionMethods = null
        };
    }

    class MagnetonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magneton";
	    public override bool doesFly => false;
    }
}
