using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidoranNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoran";

        public override float commodity => 1f;

        public override PkmnInfo info => NidoranInfo;

        public override int wildLevel => 0;

        public static PkmnInfo NidoranInfo = new PkmnInfo
        {
            Name = "Nidoran♂",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)235 / 255,
            petType = ModContent.ProjectileType<NidoranPet>(),
            evolveInto = "NidokingNPC",
            evolveAt = 0
        };
    }

    class NidoranPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoran";
	    public override bool doesFly => false;
    }
}
