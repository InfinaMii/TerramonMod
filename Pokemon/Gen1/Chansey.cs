using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ChanseyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Chansey";

        public override float commodity => 1f;

        public override PkmnInfo info => ChanseyInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ChanseyInfo = new PkmnInfo
        {
            Name = "Chansey",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)30 / 255,
            petType = ModContent.ProjectileType<ChanseyPet>(),
            evolveInto = "BlisseyNPC",
            evolveAt = 0
        };
    }

    class ChanseyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Chansey";
	    public override bool doesFly => false;
    }
}
