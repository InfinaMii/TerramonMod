using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MagnemiteNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magnemite";

        public override float commodity => 1f;

        public override PkmnInfo info => MagnemiteInfo;

        public override int wildLevel => 0;

        public static PkmnInfo MagnemiteInfo = new PkmnInfo
        {
            Name = "Magnemite",
            type1 = PkmnType.electric,
            type2 = PkmnType.steel,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<MagnemitePet>(),
            evolveInto = "MagnetonNPC",
            evolveAt = 30
        };
    }

    class MagnemitePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Magnemite";
	    public override bool doesFly => false;
    }
}
