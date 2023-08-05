using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class LickitungNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Lickitung";

        public override float commodity => 1f;

        public override PkmnInfo info => LickitungInfo;

        public override int wildLevel => 0;

        public static PkmnInfo LickitungInfo = new PkmnInfo
        {
            Name = "Lickitung",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<LickitungPet>(),
            evolutionMethods = null
        };
    }

    class LickitungPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Lickitung";
	    public override bool doesFly => false;
    }
}
