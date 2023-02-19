using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VenomothNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venomoth";

        public override float commodity => 1f;

        public override PkmnInfo info => VenomothInfo;

        public override int wildLevel => 1;

        public static PkmnInfo VenomothInfo = new PkmnInfo
        {
            Name = "Venomoth",
            type1 = PkmnType.bug,
            type2 = PkmnType.poison,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<VenomothPet>(),
            evolveInto = "VenomothNPC",
            evolveAt = -1
        };
    }

    class VenomothPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venomoth";
	    public override bool doesFly => false;
    }
}
