using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ElectabuzzNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Electabuzz";

        public override float commodity => 1f;

        public override PkmnInfo info => ElectabuzzInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ElectabuzzInfo = new PkmnInfo
        {
            Name = "Electabuzz",
            type1 = PkmnType.electric,
            type2 = null,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<ElectabuzzPet>(),
            evolutionMethods = null
        };
    }

    class ElectabuzzPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Electabuzz";
	    public override bool doesFly => false;
    }
}
