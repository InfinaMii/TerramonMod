using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VoltorbNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Voltorb";

        public override float commodity => 1f;

        public override PkmnInfo info => VoltorbInfo;

        public override int wildLevel => 0;

        public static PkmnInfo VoltorbInfo = new PkmnInfo
        {
            Name = "Voltorb",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<VoltorbPet>(),
            evolveInto = "ElectrodeNPC",
            evolveAt = 30
        };
    }

    class VoltorbPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Voltorb";
	    public override bool doesFly => false;
    }
}
