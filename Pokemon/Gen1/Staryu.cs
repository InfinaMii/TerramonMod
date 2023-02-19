using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class StaryuNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Staryu";

        public override float commodity => 1f;

        public override PkmnInfo info => StaryuInfo;

        public override int wildLevel => 0;

        public static PkmnInfo StaryuInfo = new PkmnInfo
        {
            Name = "Staryu",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)225 / 255,
            petType = ModContent.ProjectileType<StaryuPet>(),
            evolveInto = "StarmieNPC",
            evolveAt = 0
        };
    }

    class StaryuPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Staryu";
	    public override bool doesFly => false;
    }
}
