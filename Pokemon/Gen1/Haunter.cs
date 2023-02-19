using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class HaunterNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Haunter";

        public override float commodity => 1f;

        public override PkmnInfo info => HaunterInfo;

        public override int wildLevel => 1;

        public static PkmnInfo HaunterInfo = new PkmnInfo
        {
            Name = "Haunter",
            type1 = PkmnType.ghost,
            type2 = PkmnType.poison,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<HaunterPet>(),
            evolveInto = "GengarNPC",
            evolveAt = 0
        };
    }

    class HaunterPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Haunter";
	    public override bool doesFly => false;
    }
}
