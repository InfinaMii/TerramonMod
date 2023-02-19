using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GoldeenNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Goldeen";

        public override float commodity => 1f;

        public override PkmnInfo info => GoldeenInfo;

        public override int wildLevel => 0;

        public static PkmnInfo GoldeenInfo = new PkmnInfo
        {
            Name = "Goldeen",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)225 / 255,
            petType = ModContent.ProjectileType<GoldeenPet>(),
            evolveInto = "SeakingNPC",
            evolveAt = 33
        };
    }

    class GoldeenPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Goldeen";
	    public override bool doesFly => false;
    }
}
