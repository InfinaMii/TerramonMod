using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class LaprasNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Lapras";

        public override float commodity => 1f;

        public override PkmnInfo info => LaprasInfo;

        public override int wildLevel => 0;

        public static PkmnInfo LaprasInfo = new PkmnInfo
        {
            Name = "Lapras",
            type1 = PkmnType.water,
            type2 = PkmnType.ice,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<LaprasPet>(),
            evolveInto = "LaprasNPC",
            evolveAt = -1
        };
    }

    class LaprasPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Lapras";
	    public override bool doesFly => false;
    }
}
