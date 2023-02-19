using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ArcanineNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Arcanine";

        public override float commodity => 1f;

        public override PkmnInfo info => ArcanineInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ArcanineInfo = new PkmnInfo
        {
            Name = "Arcanine",
            type1 = PkmnType.fire,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<ArcaninePet>(),
            evolveInto = "ArcanineNPC",
            evolveAt = -1
        };
    }

    class ArcaninePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Arcanine";
	    public override bool doesFly => false;
    }
}
