using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ScytherNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Scyther";

        public override float commodity => 1f;

        public override PkmnInfo info => ScytherInfo;

        public override int wildLevel => 0;

        public static PkmnInfo ScytherInfo = new PkmnInfo
        {
            Name = "Scyther",
            type1 = PkmnType.bug,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<ScytherPet>(),
            evolveInto = "ScytherNPC",
            evolveAt = -1
        };
    }

    class ScytherPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Scyther";
	    public override bool doesFly => false;
    }
}
