using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PikachuNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pikachu";

        public override float commodity => 1f;

        public override PkmnInfo info => PikachuInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PikachuInfo = new PkmnInfo
        {
            Name = "Pikachu",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<PikachuPet>(),
            evolveInto = "PikachuNPC",
            evolveAt = -1
        };
    }

    class PikachuPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pikachu";
	    public override bool doesFly => false;
    }
}
