using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PidgeotNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgeot";

        public override float commodity => 1f;

        public override PkmnInfo info => PidgeotInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PidgeotInfo = new PkmnInfo
        {
            Name = "Pidgeot",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<PidgeotPet>(),
            evolveInto = "PidgeotNPC",
            evolveAt = 36
        };
    }

    class PidgeotPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgeot";
	    public override bool doesFly => false;
    }
}
