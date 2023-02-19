using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class OmanyteNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Omanyte";

        public override float commodity => 1f;

        public override PkmnInfo info => OmanyteInfo;

        public override int wildLevel => 0;

        public static PkmnInfo OmanyteInfo = new PkmnInfo
        {
            Name = "Omanyte",
            type1 = PkmnType.rock,
            type2 = PkmnType.water,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<OmanytePet>(),
            evolveInto = "OmastarNPC",
            evolveAt = 40
        };
    }

    class OmanytePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Omanyte";
	    public override bool doesFly => false;
    }
}
