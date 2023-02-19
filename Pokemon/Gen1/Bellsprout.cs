using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class BellsproutNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Bellsprout";

        public override float commodity => 1f;

        public override PkmnInfo info => BellsproutInfo;

        public override int wildLevel => 0;

        public static PkmnInfo BellsproutInfo = new PkmnInfo
        {
            Name = "Bellsprout",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)255 / 255,
            petType = ModContent.ProjectileType<BellsproutPet>(),
            evolveInto = "WeepinbellNPC",
            evolveAt = 21
        };
    }

    class BellsproutPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Bellsprout";
	    public override bool doesFly => false;
    }
}
