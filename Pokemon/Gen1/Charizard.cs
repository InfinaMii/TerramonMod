using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class CharizardNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charizard";

        public override float commodity => 1f;

        public override PkmnInfo info => CharizardInfo;

        public override int wildLevel => 1;

        public static PkmnInfo CharizardInfo = new PkmnInfo
        {
            Name = "Charizard",
            type1 = PkmnType.fire,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<CharizardPet>(),
            evolutionMethods = null
        };
    }

    class CharizardPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Charizard";
	    public override bool doesFly => false;
    }
}
