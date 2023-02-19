using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class BeedrillNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Beedrill";

        public override float commodity => 1f;

        public override PkmnInfo info => BeedrillInfo;

        public override int wildLevel => 1;

        public static PkmnInfo BeedrillInfo = new PkmnInfo
        {
            Name = "Beedrill",
            type1 = PkmnType.bug,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<BeedrillPet>(),
            evolveInto = "BeedrillNPC",
            evolveAt = 10
        };
    }

    class BeedrillPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Beedrill";
	    public override bool doesFly => false;
    }
}
