using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class NinetalesNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ninetales";

        public override float commodity => 1f;

        public override PkmnInfo info => NinetalesInfo;

        public override int wildLevel => 1;

        public static PkmnInfo NinetalesInfo = new PkmnInfo
        {
            Name = "Ninetales",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<NinetalesPet>(),
            evolutionMethods = null
        };
    }

    class NinetalesPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ninetales";
	    public override bool doesFly => false;
    }
}
