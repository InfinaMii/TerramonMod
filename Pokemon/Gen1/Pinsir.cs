using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PinsirNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pinsir";

        public override float commodity => 1f;

        public override PkmnInfo info => PinsirInfo;

        public override int wildLevel => 0;

        public static PkmnInfo PinsirInfo = new PkmnInfo
        {
            Name = "Pinsir",
            type1 = PkmnType.bug,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<PinsirPet>(),
            evolveInto = "PinsirNPC",
            evolveAt = -1
        };
    }

    class PinsirPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pinsir";
	    public override bool doesFly => false;
    }
}
