using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DragoniteNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dragonite";

        public override float commodity => 1f;

        public override PkmnInfo info => DragoniteInfo;

        public override int wildLevel => 1;

        public static PkmnInfo DragoniteInfo = new PkmnInfo
        {
            Name = "Dragonite",
            type1 = PkmnType.dragon,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<DragonitePet>(),
            evolutionMethods = null
        };
    }

    class DragonitePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dragonite";
	    public override bool doesFly => false;
    }
}
