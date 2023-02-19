using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class EkansNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ekans";

        public override float commodity => 1f;

        public override PkmnInfo info => EkansInfo;

        public override int wildLevel => 0;

        public static PkmnInfo EkansInfo = new PkmnInfo
        {
            Name = "Ekans",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<EkansPet>(),
            evolveInto = "ArbokNPC",
            evolveAt = 22
        };
    }

    class EkansPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ekans";
	    public override bool doesFly => false;
    }
}
