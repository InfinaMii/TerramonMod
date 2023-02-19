using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class BlastoiseNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Blastoise";

        public override float commodity => 1f;

        public override PkmnInfo info => BlastoiseInfo;

        public override int wildLevel => 1;

        public static PkmnInfo BlastoiseInfo = new PkmnInfo
        {
            Name = "Blastoise",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<BlastoisePet>(),
            evolveInto = "BlastoiseNPC",
            evolveAt = 36
        };
    }

    class BlastoisePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Blastoise";
	    public override bool doesFly => false;
    }
}
