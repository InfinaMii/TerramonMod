using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GengarNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gengar";

        public override float commodity => 1f;

        public override PkmnInfo info => GengarInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GengarInfo = new PkmnInfo
        {
            Name = "Gengar",
            type1 = PkmnType.ghost,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<GengarPet>(),
            evolutionMethods = null
        };
    }

    class GengarPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gengar";
	    public override bool doesFly => false;
    }
}
