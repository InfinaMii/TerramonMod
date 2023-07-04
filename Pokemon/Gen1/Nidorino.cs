using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NidorinoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidorino";

        public override float commodity => 1f;

        public override PkmnInfo info => NidorinoInfo;

        public override int wildLevel => 1;

        public static PkmnInfo NidorinoInfo = new PkmnInfo
        {
            Name = "Nidorino",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<NidorinoPet>(),
            evolveInto = "NidorinoNPC",
            evolveAt = -1
        };
    }

    class NidorinoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Nidorino";
	    public override bool doesFly => false;
    }
}
