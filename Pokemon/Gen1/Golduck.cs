using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GolduckNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golduck";

        public override float commodity => 1f;

        public override PkmnInfo info => GolduckInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GolduckInfo = new PkmnInfo
        {
            Name = "Golduck",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<GolduckPet>(),
            evolveInto = "GolduckNPC",
            evolveAt = -1
        };
    }

    class GolduckPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golduck";
	    public override bool doesFly => false;
    }
}
