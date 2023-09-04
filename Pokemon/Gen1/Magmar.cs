using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MagmarNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magmar";

        public override float commodity => 1f;

        public override PkmnInfo info => MagmarInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MagmarInfo = new PkmnInfo
        {
            Name = "Magmar",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<MagmarPet>(),
            evolutionMethods = null
        };
    }

    class MagmarPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magmar";
	    public override bool doesFly => false;
    }
}
