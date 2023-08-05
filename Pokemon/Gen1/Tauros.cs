using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class TaurosNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tauros";

        public override float commodity => 1f;

        public override PkmnInfo info => TaurosInfo;

        public override int wildLevel => 0;

        public static PkmnInfo TaurosInfo = new PkmnInfo
        {
            Name = "Tauros",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<TaurosPet>(),
            evolutionMethods = null
        };
    }

    class TaurosPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Tauros";
	    public override bool doesFly => false;
    }
}
