using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class IvysaurNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ivysaur";

        public override float commodity => 1f;

        public override PkmnInfo info => IvysaurInfo;

        public override int wildLevel => 1;

        public static PkmnInfo IvysaurInfo = new PkmnInfo
        {
            Name = "Ivysaur",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<IvysaurPet>(),
            evolveInto = "IvysaurNPC",
            evolveAt = -1
        };
    }

    class IvysaurPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ivysaur";
	    public override bool doesFly => false;
    }
}
