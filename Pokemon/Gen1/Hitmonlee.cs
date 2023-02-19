using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class HitmonleeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hitmonlee";

        public override float commodity => 1f;

        public override PkmnInfo info => HitmonleeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo HitmonleeInfo = new PkmnInfo
        {
            Name = "Hitmonlee",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<HitmonleePet>(),
            evolveInto = "HitmonleeNPC",
            evolveAt = -1
        };
    }

    class HitmonleePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hitmonlee";
	    public override bool doesFly => false;
    }
}
