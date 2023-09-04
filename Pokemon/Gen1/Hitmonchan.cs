using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class HitmonchanNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hitmonchan";

        public override float commodity => 1f;

        public override PkmnInfo info => HitmonchanInfo;

        public override int wildLevel => 0;

        public static PkmnInfo HitmonchanInfo = new PkmnInfo
        {
            Name = "Hitmonchan",
            type1 = PkmnType.fighting,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<HitmonchanPet>(),
            evolutionMethods = null
        };
    }

    class HitmonchanPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Hitmonchan";
	    public override bool doesFly => false;
    }
}
