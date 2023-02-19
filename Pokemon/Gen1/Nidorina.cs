using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidorinaNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidorina";

        public override float commodity => 1f;

        public override PkmnInfo info => NidorinaInfo;

        public override int wildLevel => 1;

        public static PkmnInfo NidorinaInfo = new PkmnInfo
        {
            Name = "Nidorina",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<NidorinaPet>(),
            evolveInto = "NidoqueenNPC",
            evolveAt = 0
        };
    }

    class NidorinaPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidorina";
	    public override bool doesFly => false;
    }
}
