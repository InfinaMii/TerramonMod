using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PoliwhirlNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwhirl";

        public override float commodity => 1f;

        public override PkmnInfo info => PoliwhirlInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PoliwhirlInfo = new PkmnInfo
        {
            Name = "Poliwhirl",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<PoliwhirlPet>(),
            evolveInto = "PoliwrathNPC",
            evolveAt = 0
        };
    }

    class PoliwhirlPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Poliwhirl";
	    public override bool doesFly => false;
    }
}
