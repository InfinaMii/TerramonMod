using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidoqueenNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoqueen";

        public override float commodity => 1f;

        public override PkmnInfo info => NidoqueenInfo;

        public override int wildLevel => 1;

        public static PkmnInfo NidoqueenInfo = new PkmnInfo
        {
            Name = "Nidoqueen",
            type1 = PkmnType.poison,
            type2 = PkmnType.ground,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<NidoqueenPet>(),
            evolveInto = "NidoqueenNPC",
            evolveAt = 0
        };
    }

    class NidoqueenPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidoqueen";
	    public override bool doesFly => false;
    }
}
