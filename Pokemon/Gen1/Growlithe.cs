using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GrowlitheNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Growlithe";

        public override float commodity => 1f;

        public override PkmnInfo info => GrowlitheInfo;

        public override int wildLevel => 0;

        public static PkmnInfo GrowlitheInfo = new PkmnInfo
        {
            Name = "Growlithe",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<GrowlithePet>(),
            evolveInto = "ArcanineNPC",
            evolveAt = 6
        };
    }

    class GrowlithePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Growlithe";
	    public override bool doesFly => false;
    }
}
