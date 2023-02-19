using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class OmastarNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Omastar";

        public override float commodity => 1f;

        public override PkmnInfo info => OmastarInfo;

        public override int wildLevel => 1;

        public static PkmnInfo OmastarInfo = new PkmnInfo
        {
            Name = "Omastar",
            type1 = PkmnType.rock,
            type2 = PkmnType.water,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<OmastarPet>(),
            evolveInto = "OmastarNPC",
            evolveAt = -1
        };
    }

    class OmastarPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Omastar";
	    public override bool doesFly => false;
    }
}
