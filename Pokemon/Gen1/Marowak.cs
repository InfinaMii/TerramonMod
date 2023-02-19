using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MarowakNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Marowak";

        public override float commodity => 1f;

        public override PkmnInfo info => MarowakInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MarowakInfo = new PkmnInfo
        {
            Name = "Marowak",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<MarowakPet>(),
            evolveInto = "MarowakNPC",
            evolveAt = -1
        };
    }

    class MarowakPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Marowak";
	    public override bool doesFly => false;
    }
}
