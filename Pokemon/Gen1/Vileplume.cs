using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VileplumeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vileplume";

        public override float commodity => 1f;

        public override PkmnInfo info => VileplumeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo VileplumeInfo = new PkmnInfo
        {
            Name = "Vileplume",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<VileplumePet>(),
            evolveInto = "VileplumeNPC",
            evolveAt = -1
        };
    }

    class VileplumePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Vileplume";
	    public override bool doesFly => false;
    }
}
