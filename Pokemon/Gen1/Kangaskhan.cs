using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KangaskhanNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kangaskhan";

        public override float commodity => 1f;

        public override PkmnInfo info => KangaskhanInfo;

        public override int wildLevel => 0;

        public static PkmnInfo KangaskhanInfo = new PkmnInfo
        {
            Name = "Kangaskhan",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<KangaskhanPet>(),
            evolveInto = "KangaskhanNPC",
            evolveAt = -1
        };
    }

    class KangaskhanPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kangaskhan";
	    public override bool doesFly => false;
    }
}
