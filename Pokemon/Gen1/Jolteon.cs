using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class JolteonNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jolteon";

        public override float commodity => 1f;

        public override PkmnInfo info => JolteonInfo;

        public override int wildLevel => 1;

        public static PkmnInfo JolteonInfo = new PkmnInfo
        {
            Name = "Jolteon",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<JolteonPet>(),
            evolutionMethods = null
        };
    }

    class JolteonPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Jolteon";
	    public override bool doesFly => false;
    }
}
