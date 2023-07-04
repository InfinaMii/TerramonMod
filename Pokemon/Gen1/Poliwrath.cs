using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PoliwrathNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwrath";

        public override float commodity => 1f;

        public override PkmnInfo info => PoliwrathInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PoliwrathInfo = new PkmnInfo
        {
            Name = "Poliwrath",
            type1 = PkmnType.water,
            type2 = PkmnType.fighting,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<PoliwrathPet>(),
            evolveInto = "PoliwrathNPC",
            evolveAt = -1
        };
    }

    class PoliwrathPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwrath";
	    public override bool doesFly => false;
    }
}
