using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VaporeonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vaporeon";

        public override float commodity => 1f;

        public override PkmnInfo info => VaporeonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo VaporeonInfo = new PkmnInfo
        {
            Name = "Vaporeon",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<VaporeonPet>(),
            evolveInto = "VaporeonNPC",
            evolveAt = -1
        };
    }

    class VaporeonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vaporeon";
	    public override bool doesFly => false;
    }
}
