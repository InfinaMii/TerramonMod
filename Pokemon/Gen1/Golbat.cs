using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GolbatNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golbat";

        public override float commodity => 1f;

        public override PkmnInfo info => GolbatInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GolbatInfo = new PkmnInfo
        {
            Name = "Golbat",
            type1 = PkmnType.poison,
            type2 = PkmnType.flying,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<GolbatPet>(),
            evolveInto = "CrobatNPC",
            evolveAt = 0
        };
    }

    class GolbatPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Golbat";
	    public override bool doesFly => false;
    }
}
