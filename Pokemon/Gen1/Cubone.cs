using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CuboneNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Cubone";

        public override float commodity => 1f;

        public override PkmnInfo info => CuboneInfo;

        public override int wildLevel => 0;

        public static PkmnInfo CuboneInfo = new PkmnInfo
        {
            Name = "Cubone",
            type1 = PkmnType.ground,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<CubonePet>(),
            evolveInto = "MarowakNPC",
            evolveAt = 28
        };
    }

    class CubonePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Cubone";
	    public override bool doesFly => false;
    }
}
