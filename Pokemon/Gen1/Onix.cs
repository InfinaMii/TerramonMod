using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class OnixNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Onix";

        public override float commodity => 1f;

        public override PkmnInfo info => OnixInfo;

        public override int wildLevel => 0;

        public static PkmnInfo OnixInfo = new PkmnInfo
        {
            Name = "Onix",
            type1 = PkmnType.rock,
            type2 = PkmnType.ground,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<OnixPet>(),
            evolutionMethods = null
        };
    }

    class OnixPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Onix";
	    public override bool doesFly => false;
    }
}
