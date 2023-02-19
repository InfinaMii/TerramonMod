using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class RapidashNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rapidash";

        public override float commodity => 1f;

        public override PkmnInfo info => RapidashInfo;

        public override int wildLevel => 1;

        public static PkmnInfo RapidashInfo = new PkmnInfo
        {
            Name = "Rapidash",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<RapidashPet>(),
            evolveInto = "RapidashNPC",
            evolveAt = -1
        };
    }

    class RapidashPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Rapidash";
	    public override bool doesFly => false;
    }
}
