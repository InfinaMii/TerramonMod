using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KabutopsNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kabutops";

        public override float commodity => 1f;

        public override PkmnInfo info => KabutopsInfo;

        public override int wildLevel => 1;

        public static PkmnInfo KabutopsInfo = new PkmnInfo
        {
            Name = "Kabutops",
            type1 = PkmnType.rock,
            type2 = PkmnType.water,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<KabutopsPet>(),
            evolutionMethods = null
        };
    }

    class KabutopsPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kabutops";
	    public override bool doesFly => false;
    }
}
