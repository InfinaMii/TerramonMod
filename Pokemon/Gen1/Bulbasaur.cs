using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class BulbasaurNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Bulbasaur";

        public override float commodity => 1f;

        public override PkmnInfo info => BulbasaurInfo;

        public override int wildLevel => 0;

        public static PkmnInfo BulbasaurInfo = new PkmnInfo
        {
            Name = "Bulbasaur",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<BulbasaurPet>(),
            evolveInto = "IvysaurNPC",
            evolveAt = 16
        };
    }

    class BulbasaurPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Bulbasaur";
	    public override bool doesFly => false;
    }
}
