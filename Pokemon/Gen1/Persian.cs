using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PersianNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Persian";

        public override float commodity => 1f;

        public override PkmnInfo info => PersianInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PersianInfo = new PkmnInfo
        {
            Name = "Persian",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<PersianPet>(),
            evolveInto = "PersianNPC",
            evolveAt = -1
        };
    }

    class PersianPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Persian";
	    public override bool doesFly => false;
    }
}
