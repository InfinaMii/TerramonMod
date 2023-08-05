using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class SlowbroNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Slowbro";

        public override float commodity => 1f;

        public override PkmnInfo info => SlowbroInfo;

        public override int wildLevel => 1;

        public static PkmnInfo SlowbroInfo = new PkmnInfo
        {
            Name = "Slowbro",
            type1 = PkmnType.water,
            type2 = PkmnType.psychic,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<SlowbroPet>(),
            evolutionMethods = null
        };
    }

    class SlowbroPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Slowbro";
	    public override bool doesFly => false;
    }
}
