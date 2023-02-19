using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class JigglypuffNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jigglypuff";

        public override float commodity => 1f;

        public override PkmnInfo info => JigglypuffInfo;

        public override int wildLevel => 1;

        public static PkmnInfo JigglypuffInfo = new PkmnInfo
        {
            Name = "Jigglypuff",
            type1 = PkmnType.normal,
            type2 = PkmnType.fairy,
            captureRate = (float)170 / 255,
            petType = ModContent.ProjectileType<JigglypuffPet>(),
            evolveInto = "WigglytuffNPC",
            evolveAt = 0
        };
    }

    class JigglypuffPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jigglypuff";
	    public override bool doesFly => false;
    }
}
