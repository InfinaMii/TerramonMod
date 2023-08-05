using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ButterfreeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Butterfree";

        public override float commodity => 1f;

        public override PkmnInfo info => ButterfreeInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ButterfreeInfo = new PkmnInfo
        {
            Name = "Butterfree",
            type1 = PkmnType.bug,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<ButterfreePet>(),
            evolutionMethods = null
        };
    }

    class ButterfreePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Butterfree";
	    public override bool doesFly => false;
    }
}
